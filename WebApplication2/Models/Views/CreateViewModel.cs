using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Models.Views
{
    public class CreateViewModel
    {
        public SelectList Authors { get; set; }
        public SelectList Series { get; set; }
    }
}
