﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delicious.Feature.Recipes.Models
{
  public class FeaturedRecipes
  {
    public Recipe FeaturedRecipe { get; set; }
    public List<Recipe> FeaturedRecipesList { get; set; }
  }
}