using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailrXamarin.Models.ResponseModels
{
    public class GetCocktailById
    {
        public List<GetCocktailByIdDrink> drinks { get; set; }
    }
}
