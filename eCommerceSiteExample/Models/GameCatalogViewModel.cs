namespace eCommerceSiteExample.Models
{
    public class GameCatalogViewModel
    {
        public GameCatalogViewModel(List<Game> games, int lastPage, int currentPage)
        {
            Games = games;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<Game> Games { get; private set; }

        /// <summary>
        /// THe last page of the catalog
        /// calculated using total number of products
        /// divided by products per page
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// The current page the user is viewing
        /// </summary>
        public int CurrentPage { get; private set; }

    }
}
