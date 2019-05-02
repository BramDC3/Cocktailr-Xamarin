using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailrXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CocktailDetailPage : ContentPage
	{
		public CocktailDetailPage ()
		{
			InitializeComponent ();
            BindingContext = App.cocktailViewModel.SelectedCocktail;
            //Title = App.cocktailViewModel.SelectedCocktail.Name;
            Title = App.cocktailViewModel.SelectedCocktail.IngredientMeasurements[0].Ingredient;
        }
	}
}