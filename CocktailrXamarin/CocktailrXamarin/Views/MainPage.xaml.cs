using CocktailrXamarin.Views;
using Xamarin.Forms;

namespace CocktailrXamarin
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            var cocktailListPage = new NavigationPage(new CocktailListPage())
            {
                Icon = "cocktail.png",
                Title = "Cocktails"
            };

            var addSuggestionPage = new NavigationPage(new AddSuggestionPage())
            {
                Icon = "addphoto.png",
                Title = "Suggestion"
            };

            Children.Add(cocktailListPage);
            Children.Add(addSuggestionPage);
        }
    }
}
