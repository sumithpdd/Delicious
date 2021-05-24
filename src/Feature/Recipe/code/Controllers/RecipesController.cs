using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Diagnostics;
using Delicious.Feature.Recipes.Models;
using Delicious.Feature.Recipes.Helpers;
using System.Xml;

namespace Delicious.Feature.Recipes.Controllers
{
    public class RecipesController : Controller
  {


    public ActionResult LatestRecipes()
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

      LatestRecipes latestRecipes = new LatestRecipes();

      //Event Links - DropTree Field with Child Items
      //ReferenceField RecipeRoot = item.Fields[Templates.LatestRecipes.Fields.LatestRecipesList];
      List<Recipe> RecipeAlbumList = new List<Recipe>();

      MultilistField latestRecipesListField = item.Fields[Templates.LatestRecipes.Fields.LatestRecipesList];
      Item[] latestRecipeItems = latestRecipesListField.GetItems();

      //foreach (Item i in RecipeRoot.TargetItem.Children)
      if (latestRecipeItems != null && latestRecipeItems.Count() > 0)
      {
        foreach (Item i in latestRecipeItems)
        {

          Recipe Recipe = new Recipe();
          Item RecipeItem = Sitecore.Context.Database.GetItem(i.ID);
          Recipe.RecipeName = RecipeItem.Fields[Templates.Recipe.Fields.RecipeName.ToString()].Value; 
          Recipe.RecipeDescription = RecipeItem.Fields[Templates.Recipe.Fields.RecipeDescription.ToString()].Value; 
          ImageField RecipeImage = RecipeItem.Fields[Templates.Recipe.Fields.RecipeImage];

          XmlDocument doc = new XmlDocument();
          //doc.LoadXml("<image stylelabs-content-id=\"29865\" thumbnailsrc=\"https://cmp-connector-400-r147.stylelabsqa.com/api/gateway/29865/thumbnail\" src=\"https://cmp-connector-400-r147.stylelabsqa.com/api/public/content/19c8d2004811433d931cc13c1d0b138a?v=638d2b04\" mediaid=\"\" stylelabs-content-type=\"Image\" alt=\"can-of-coke.jpg\" height=\"879\" width=\"1200\" />");
          doc.LoadXml(RecipeImage.Value);

          XmlElement root = doc.DocumentElement;

          string src = root.Attributes["src"] !=null? root.Attributes["src"].Value: string.Empty;

          if (!string.IsNullOrEmpty(src))
          {
            Recipe.RecipeImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(RecipeImage.MediaItem);
          }
          else
          {
            Recipe.RecipeImageUrl = src;

          }

          Recipe.RecipeImageAlt = RecipeImage.Alt;

          RecipeAlbumList.Add(Recipe);
        }
      }

      //Featured Recipes List - TreeList Field

      //MultilistField latestRecipesListField = item.Fields[Templates.LatestRecipes.Fields.LatestRecipesList];
      //Item[] latestRecipeItems = latestRecipesListField.GetItems();
      // if (latestRecipeItems != null && latestRecipeItems.Count() > 0)
      //{
      //  foreach (Item i in latestRecipeItems)
      //  {
      //    Recipe Recipe = new Recipe();
      //    Item RecipeItem = Sitecore.Context.Database.GetItem(i.ID);
      //    Recipe.RecipeName = RecipeItem.Fields[Templates.Recipe.Fields.RecipeName.ToString()].Value;
      //    Recipe.RecipeTitle = RecipeItem.Fields[Templates.Recipe.Fields.RecipeTitle.ToString()].Value;
      //    Recipe.RecipeDescription = RecipeItem.Fields[Templates.Recipe.Fields.RecipeDescription.ToString()].Value;
      //    LinkField RecipeTwitterLink = RecipeItem.Fields[Templates.Recipe.Fields.RecipeTwitterUrl];
      //    Recipe.RecipeTwitterUrl = RecipeTwitterLink.Url;
      //    LinkField RecipeLinkedInLink = RecipeItem.Fields[Templates.Recipe.Fields.RecipeLinkedInUrl];
      //    Recipe.RecipeLinkedInUrl = RecipeLinkedInLink.Url;
      //    LinkField RecipeWebsiteLink = RecipeItem.Fields[Templates.Recipe.Fields.RecipeWebsiteUrl];
      //    Recipe.RecipeWebsiteUrl = RecipeWebsiteLink.Url;
      //    ImageField RecipeImage = RecipeItem.Fields[Templates.Recipe.Fields.RecipeImage];
      //    Recipe.RecipeImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(RecipeImage.MediaItem);
      //    Recipe.RecipeImageAlt = RecipeImage.Alt;

      //    RecipeAlbumList.Add(Recipe);
      //  }
      //}

      latestRecipes.LatestRecipesList = RecipeAlbumList;

      return View(latestRecipes);
    }

    public ActionResult FeaturedRecipes()
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

      FeaturedRecipes featuredRecipes = new FeaturedRecipes();

      //Featured Recipe - DropTree Field
      ReferenceField featuredRecipeField = item.Fields[Templates.FeaturedRecipe.Fields.FeaturedRecipe];
      Item featuredRecipeItem = Sitecore.Context.Database.GetItem(featuredRecipeField.TargetID);
      if (featuredRecipeItem != null)
      {
        Recipe featuredRecipe = new Recipe();
        featuredRecipe.RecipeName = featuredRecipeItem.Fields[Templates.Recipe.Fields.RecipeName.ToString()].Value; 
        featuredRecipe.RecipeDescription = featuredRecipeItem.Fields[Templates.Recipe.Fields.RecipeDescription.ToString()].Value;
        featuredRecipes.FeaturedRecipe = featuredRecipe;
        ImageField featuredRecipeImage = featuredRecipeItem.Fields[Templates.Recipe.Fields.RecipeImage];
        featuredRecipe.RecipeImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(featuredRecipeImage.MediaItem);
        featuredRecipe.RecipeImageAlt = featuredRecipeImage.Alt;
      }

      //Featured Recipes List - TreeList Field
      MultilistField featuredRecipesListField = item.Fields[Templates.FeaturedRecipe.Fields.FeaturedRecipesList];
      Item[] featuredRecipeItems = featuredRecipesListField.GetItems();
      List<Recipe> featuredRecipesList = new List<Recipe>();
      if (featuredRecipeItems != null && featuredRecipeItems.Count() > 0)
      {
        foreach (Item i in featuredRecipeItems)
        {
          Recipe recipe = new Recipe();
          Item recipeItem = Sitecore.Context.Database.GetItem(i.ID);
          recipe.RecipeName = recipeItem.Fields[Templates.Recipe.Fields.RecipeName.ToString()].Value;
           recipe.RecipeDescription = recipeItem.Fields[Templates.Recipe.Fields.RecipeDescription.ToString()].Value;
              ImageField recipeImage = recipeItem.Fields[Templates.Recipe.Fields.RecipeImage];
          recipe.RecipeImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(recipeImage.MediaItem);
          recipe.RecipeImageAlt = recipeImage.Alt;

          featuredRecipesList.Add(recipe);
        }
      }

      featuredRecipes.FeaturedRecipesList = featuredRecipesList;

      return View(featuredRecipes);
    }
  }
}