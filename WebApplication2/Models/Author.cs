using System.ComponentModel;

namespace WebApplication2.Models
{
    public class Author
    {
        public int Id { get; set; }
        [DisplayName("Имя автора")]
        public string Name { get; set; } = "";
        [DisplayName("Год рождения автора")]
        public int YearBirth { get; set; }
    }
}
