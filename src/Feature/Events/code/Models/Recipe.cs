using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delicious.Feature.Events.Models
{
  public class Recipe
  {
    public string RecipeName { get; set; }
    public string RecipeTitle { get; set; }
    public string RecipeImageUrl { get; set; }
    public string RecipeImageAlt { get; set; }
    public string RecipeDescription { get; set; }
    public string RecipeTwitterUrl { get; set; }
    public string RecipeLinkedInUrl { get; set; }
    public string RecipeWebsiteUrl { get; set; }
  }
}