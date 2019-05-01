using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailrXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IngredientsListPage : ContentPage
	{
		public IngredientsListPage ()
		{
			InitializeComponent ();
            BindingContext = App.cocktailViewModel;
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await App.cocktailViewModel.FetchCocktailsByIngredient(e.Item.ToString());
            await Navigation.PopAsync();
            App.cocktailViewModel.FilterIngredients("");
        }

        private void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            App.cocktailViewModel.FilterIngredients(e.NewTextValue);
        }
    }
}