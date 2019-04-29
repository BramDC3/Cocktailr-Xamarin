using CocktailrXamarin.Base;
using CocktailrXamarin.Models;
using CocktailrXamarin.Network;
using System;
using System.Collections.Generic;
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

        private List<string> _ingredients;
        public List<string> Ingredients
        {
            get => _ingredients;
            set { _ingredients = value; RaisePropertyChanged(nameof(Ingredients)); }
        }

        private List<Cocktail> _cocktails;
        public List<Cocktail> Cocktails
        {
            get => _cocktails;
            set { _cocktails = value; RaisePropertyChanged(nameof(Cocktails)); }
        }

        public CocktailViewModel()
        {
            cocktailApi = new CocktailApi();
        }

        public async Task FetchIngredients() => Ingredients = await cocktailApi.GetAllIngredients();

        public async Task FetchCocktailsByIngredient(string ingredient) => Cocktails = await cocktailApi.GetCocktailsByIngredient(ingredient);

        public async Task FetchCocktailById(Cocktail cocktail) => SelectedCocktail = await cocktailApi.GetCocktailById(cocktail);
    }
}
