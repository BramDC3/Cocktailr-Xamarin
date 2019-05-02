using System.Collections.Generic;

namespace CocktailrXamarin.Models
{
    public class Cocktail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Instructions { get; set; }
        public string ImageUrl { get; set; }
        public List<IngredientMeasurement> IngredientMeasurements { get; set; } = new List<IngredientMeasurement>();
    }

   public class IngredientMeasurement
    {
        public string Ingredient { get; set; }
        public string Measurement { get; set; }

        public IngredientMeasurement(string Ingredient, string Measurement)
        {
            this.Ingredient = Ingredient;
            this.Measurement = Measurement;
        }
    }
}
