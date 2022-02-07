using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models.Views;
using AutoMapper;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext applicationContext;
        private IMapper _mapper;

        public HomeController(ApplicationContext context, IMapper mapper)
        {
            applicationContext = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string searchName, int page = 1)
        {
            int pageSize = 3;   // количество элементов на странице
            IQueryable<Book> books = applicationContext.Books.Include(x => x.Author);

            // поиск
            if (!String.IsNullOrEmpty(searchName))
            {
                books = books.Where(p => p.Name!.Contains(searchName)).Include(x => x.Author);
            }

            // пагинация
            var count = await books.CountAsync();
            var items = await books.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SearchViewModel = new SearchViewModel(searchName),
                Books = items
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var authors = new SelectList(applicationContext.Authors.Select(x => new { x.Id, x.Name }), "Id", "Name");
            var series = new SelectList(applicationContext.Series.Select(x => new { x.Id, x.Name }), "Id", "Name");
            CreateViewModel viewModel = new CreateViewModel
            {
                Authors = authors,
                Series = series
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            applicationContext.Books.Add(book);
            await applicationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            IQueryable<Book> books = applicationContext.Books
                .Include(x => x.Author)
                .Include(z => z.Series);
            if (id != null)
            {
                Book book = await applicationContext.Books
                    .Include(x => x.Author)
                    .Include(z => z.Series)
                    .FirstOrDefaultAsync(p => p.Id == id);
                var stores = applicationContext.Stores.Include(c => c.Books).ToList();

                if (book != null)
                {
                    books = books.Where(x => x.AuthorId == book.AuthorId && x.Name != book.Name).Include(x => x.Stores);
                    var booksSeries = books.Where(x => x.SeriesId == book.SeriesId && x.Name != book.Name);
                    

                    DetailsViewModel viewModel = new DetailsViewModel
                    {
                        Books = books,
                        BooksSeries = booksSeries,
                        Book = book,
                        Stores = stores,
                    };
                    return View(viewModel);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Book book = await applicationContext.Books
                    .Include(x => x.Author)
                    .FirstOrDefaultAsync(p => p.Id == id);
                if (book != null)
                    return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Book book = await applicationContext.Books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null)
                {
                    applicationContext.Books.Remove(book);
                    await applicationContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Book book = await applicationContext.Books
                    .Include(x => x.Author)
                    .Include(z => z.Series)
                    .FirstOrDefaultAsync(p => p.Id == id);
            if (book != null)
            {
                var bookView = _mapper.Map<BookView>(book);
                bookView.Authors = new SelectList(applicationContext.Authors.Select(x => new { x.Id, x.Name }), "Id", "Name");
                bookView.Series = new SelectList(applicationContext.Series.Select(z => new { z.Id, z.Name }), "Id", "Name");
                return View(bookView);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            applicationContext.Books.Update(book);
            await applicationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
