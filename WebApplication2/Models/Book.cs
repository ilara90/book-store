using System.ComponentModel;

namespace WebApplication2.Models
{
    public class Book
    {
        [DisplayName("№ книги")]
        public int Id { get; set; }
        [DisplayName("Название книги")]
        public string Name { get; set; } = "";
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int? SeriesId { get; set; }
        public Series? Series { get; set; }
        //public Store? Stores { get; set; }
        public List<Store> Stores { get; set; } = new();
        public List<BooksStores> BooksStores { get; set; } = new();
    }
}

