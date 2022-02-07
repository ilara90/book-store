namespace WebApplication2.Models.Views
{
    public class DetailsViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Book> BooksSeries { get; set; }
        public Book Book { get; set; }
        public IEnumerable<Store> Stores { get; set; }
    }
}
