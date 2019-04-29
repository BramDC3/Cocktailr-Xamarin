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
        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Measurements { get; set; } = new List<string>();
    }
}
