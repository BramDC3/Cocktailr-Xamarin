using CocktailrXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CocktailrXamarin
{
    public partial class App : Application
    {
        public static CocktailViewModel cocktailViewModel { get; } = new CocktailViewModel();

        public App()
        {
            InitializeComponent();

            cocktailViewModel.FetchIngredients();
            cocktailViewModel.FetchCocktailsByIngredient("Tequila");

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
