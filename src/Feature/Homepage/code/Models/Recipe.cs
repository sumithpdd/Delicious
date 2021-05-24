using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delicious.Feature.Homepage.Models
{
  public class Recipe
  {
    public string RecipeName { get; set; }
    public string RecipeId { get; set; }
    public string RecipeDescription{ get; set; }
    public string RecipeAbscractText { get; set; }
    public string RecipeAbscractImageUrl { get; set; }
    public string RecipeURL { get; set; }
    public int RecipeRating { get; set; }
  }
}