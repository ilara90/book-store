namespace WebApplication2.Models
{
    public class BooksStores
    {
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public int StoreId { get; set; }
        public Store? Store { get; set; }
    }
}
