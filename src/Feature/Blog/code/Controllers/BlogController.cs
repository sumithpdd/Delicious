using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using Delicious.Feature.Blog.Models;

namespace Delicious.Feature.Blog.Controllers
{
    public class BlogController : Controller
  {
    public ActionResult BlogDetails()
    {
      if (Sitecore.Context.Item == null)
      {
        return null;
      }

      var dataSourceId = Sitecore.Context.Item.ID.ToString();
      Assert.IsNotNullOrEmpty(dataSourceId, "dataSourceId is null or empty");
      var item = Sitecore.Context.Database.GetItem(dataSourceId);
      if (item == null)
      {
        return null;
      }

      BlogDetail BlogDetail = new BlogDetail();

       
      // Recipes List - TreeList Field
      MultilistField BlogRecipesListField = item.Fields[Templates.Blog.Fields.BlogRecipes];
      Item[] BlogRecipesItems = BlogRecipesListField.GetItems();
      List<Recipe> BlogRecipesList = new List<Recipe>();
      if (BlogRecipesItems != null && BlogRecipesItems.Count() > 0)
      {
        foreach (Item i in BlogRecipesItems)
        {
          Recipe Recipe = new Recipe();
          Item RecipeItem = Sitecore.Context.Database.GetItem(i.ID);
          Recipe.RecipeName = RecipeItem.Fields[Templates.Recipe.Fields.RecipeName.ToString()].Value;
          Recipe.RecipeTitle = RecipeItem.Fields[Templates.Recipe.Fields.RecipeTitle.ToString()].Value;
          Recipe.RecipeDescription = RecipeItem.Fields[Templates.Recipe.Fields.RecipeDescription.ToString()].Value;
          LinkField RecipeTwitterLink = RecipeItem.Fields[Templates.Recipe.Fields.RecipeTwitterUrl];
          Recipe.RecipeTwitterUrl = RecipeTwitterLink.Url;
          LinkField RecipeLinkedInLink = RecipeItem.Fields[Templates.Recipe.Fields.RecipeLinkedInUrl];
          Recipe.RecipeLinkedInUrl = RecipeLinkedInLink.Url;
          LinkField RecipeWebsiteLink = RecipeItem.Fields[Templates.Recipe.Fields.RecipeWebsiteUrl];
          Recipe.RecipeWebsiteUrl = RecipeWebsiteLink.Url;
          ImageField RecipeImage = RecipeItem.Fields[Templates.Recipe.Fields.RecipeImage];
          Recipe.RecipeImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(RecipeImage.MediaItem);
          Recipe.RecipeImageAlt = RecipeImage.Alt;

          BlogRecipesList.Add(Recipe);
        }
      }

      BlogDetail.BlogRecipeList = BlogRecipesList;

      return View(BlogDetail);
    }
     
     
  }
}