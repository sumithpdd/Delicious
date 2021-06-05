using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Delicious.Feature.Recipes.Models
{
  public class Recipe
  {
    public Item RecipeItem { get; set; }
    public string RecipeName { get; set; }
    public string RecipeId { get; set; }
    public string RecipeDescription { get; set; }
    public string RecipeAbscractText { get; set; }
    public string RecipeAbscractImageUrl { get; set; }
    public string RecipeURL { get; set; }
    public int RecipeRating { get; set; }
    public string RecipeImageUrl { get; set; }
    public string RecipeImageAlt { get; internal set; }

    public List<RecipeIngredientQuantity> Ingredients { get; internal set; }
  }

  public class RecipeIngredientQuantity
  {
    
    public string RecipeIngredient { get; internal set; }
    public string IngredientQuantity { get; internal set; }
    public string IngredientQuantityCalories { get; internal set; }
    public string RecipeIngredientText { get; internal set; }
    

  }
}