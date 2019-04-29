using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailrXamarin.Models.ResponseModels
{
    public class GetAllIngredients
    {
        public List<GetAllIngredientsDrink> drinks { get; set; }
    }
}
