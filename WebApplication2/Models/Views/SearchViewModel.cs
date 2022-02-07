namespace WebApplication2.Models.Views
{
    public class SearchViewModel
    {
        public SearchViewModel (string search)
        {
            SelectedSearch = search;
        }
        public string SelectedSearch { get; private set; }
    }
}
