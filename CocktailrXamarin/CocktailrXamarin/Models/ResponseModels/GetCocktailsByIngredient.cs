using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailrXamarin.Models.ResponseModels
{
    public class GetCocktailsByIngredient
    {
        public List<GetCocktailsByIngredientDrink> drinks { get; set; }
    }
}
