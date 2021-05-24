using System;
using System.Collections.Generic;

namespace Delicious.Feature.Homepage.Models
{
  public class Homepage
  { 
    public List<Hero> HeroSlides { get; set; }
    public List<Recipe> TopCategoryRecipe { get; set; }

    public string BestRecipesTitle { get; set; }
    public List<Recipe> BestRecipesList { get; set; }

  }
}