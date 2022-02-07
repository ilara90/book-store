using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Models.Views
{
    public class BookView : Book
    {
        public SelectList Authors { get; set; }
        public SelectList Series { get; set; }
    }
}
