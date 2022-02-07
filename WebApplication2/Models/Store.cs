namespace WebApplication2.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public List<Book> Books { get; set; } = new();
        public List<BooksStores> BooksStores { get; set; } = new();
    }
}
