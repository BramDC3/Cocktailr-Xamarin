using CocktailrXamarin.Base;
using CocktailrXamarin.Models;
using CocktailrXamarin.Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailrXamarin.ViewModels
{
    public class CocktailViewModel : ViewModelBase
    {
        private CocktailApi cocktailApi;

        private Cocktail _selectedCocktail;
        public Cocktail SelectedCocktail
        {
            get => _selectedCocktail;
            set { _selectedCocktail = value; RaisePropertyChanged(nameof(SelectedCocktail)); }
        }

        private List<string> _ingredients = new List<string>();
        private List<string> Ingredients
        {
            get => _ingredients;
            set { _ingredients = value; FilterIngredients(""); }
        }

        private ObservableCollection<string> _filteredIngredients = new ObservableCollection<string>();
        public ObservableCollection<string> FilteredIngredients
        {
            get => _filteredIngredients;
            set { _filteredIngredients = value; RaisePropertyChanged(nameof(FilteredIngredients)); }
        }

        private ObservableCollection<Cocktail> _cocktails = new ObservableCollection<Cocktail>();
        public ObservableCollection<Cocktail> Cocktails
        {
            get => _cocktails;
            set { _cocktails = value; RaisePropertyChanged(nameof(Cocktails)); }
        }

        public CocktailViewModel()
        {
            cocktailApi = new CocktailApi();
        }

        public async Task FetchIngredients() => Ingredients = await cocktailApi.GetAllIngredients();

        public async Task FetchCocktailsByIngredient(string ingredient) => Cocktails = new ObservableCollection<Cocktail>(await cocktailApi.GetCocktailsByIngredient(ingredient));

        public async Task FetchCocktailById(Cocktail cocktail) => SelectedCocktail = await cocktailApi.GetCocktailById(cocktail);

        public void FilterIngredients(string filter)
        {
            FilteredIngredients = filter == "" ? new ObservableCollection<string>(Ingredients) : new ObservableCollection<string>(Ingredients.Where((i) => i.ToLower().Contains(filter.ToLower())));
        }
    }
}
