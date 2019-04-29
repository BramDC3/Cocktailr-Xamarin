using CocktailrXamarin.Models;
using CocktailrXamarin.Models.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CocktailrXamarin.Network
{
    public class CocktailApi
    {
        private HttpClient _client;
        private string BASE_URL = "https://www.thecocktaildb.com/api/json/v1/36578";

        public CocktailApi()
        {
            _client = new HttpClient();
        }

        public async Task<List<string>> GetAllIngredients()
        {
            List<string> ingredients = new List<string>();
            try
            {
                var uri = new Uri(string.Format($"{BASE_URL}/list.php?i=list"));
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetAllIngredients>(content);
                    ingredients = result.drinks.Select(i => i.strIngredient1).ToList();
                }
                else
                {
                    Debug.WriteLine("Error fetching ingredients.");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return ingredients;
        }

        public async Task<List<Cocktail>> GetCocktailsByIngredient(string ingredient)
        {
            List<Cocktail> cocktails = new List<Cocktail>();
            try
            {
                var uri = new Uri(string.Format($"{BASE_URL}/filter.php?i={ingredient}"));
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetCocktailsByIngredient>(content);
                    cocktails = result.drinks.Select(c => new Cocktail
                    {
                        Id = c.idDrink,
                        ImageUrl = c.strDrinkThumb,
                        Name = c.strDrink,
                    }).ToList();
                }
                else
                {
                    Debug.WriteLine("Error fetching cocktails by ingredient.");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return cocktails;
        }

        public async Task<Cocktail> GetCocktailById(Cocktail cocktail)
        {
            try
            {
                var uri = new Uri(string.Format($"{BASE_URL}/lookup.php?i={cocktail.Id}"));
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetCocktailById>(content).drinks[0];
                    cocktail.Category = result.strCategory;
                    cocktail.Instructions = result.strInstructions;
                    cocktail.Ingredients = GetIngredients(result);
                    cocktail.Measurements = GetMeasurements(result);
                }
                else
                {
                    Debug.WriteLine("Error fetching cocktail by id.");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return cocktail;
        }

        private List<string> GetIngredients(GetCocktailByIdDrink c)
        {
            return new List<string> {
                c.strIngredient1, c.strIngredient2, c.strIngredient3, c.strIngredient4, c.strIngredient5, c.strIngredient6, c.strIngredient7, c.strIngredient8, c.strIngredient9, c.strIngredient10, c.strIngredient11, c.strIngredient12, c.strIngredient13, c.strIngredient14, c.strIngredient15
            }.Where(i => i != "" && i != " " && i != "\n" && i != null).ToList();
        }

        private List<string> GetMeasurements(GetCocktailByIdDrink c)
        {
            return new List<string> {
                c.strMeasure1, c.strMeasure2, c.strMeasure3, c.strMeasure4, c.strMeasure5, c.strMeasure6, c.strMeasure7, c.strMeasure8, c.strMeasure9, c.strMeasure10, c.strMeasure11, c.strMeasure12, c.strMeasure13, c.strMeasure14, c.strMeasure15
            }.Where(i => i != "" && i != " " && i != "\n" && i != null).ToList();
        }
    }

}
