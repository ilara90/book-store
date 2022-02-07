using WebApplication2.Models.Views;

namespace WebApplication2.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SearchViewModel SearchViewModel { get; set; }
    }
}
