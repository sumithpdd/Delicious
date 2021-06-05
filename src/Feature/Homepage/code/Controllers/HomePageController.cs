using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Diagnostics;
using Delicious.Feature.Homepage;
using HomepageModel = Delicious.Feature.Homepage.Models  ;
using Delicious.Feature.Homepage.Models;
using System.Xml;

namespace Delicious.Feature.Homepage.Controllers
{
  public class HomePageController : Controller
  {


    public ActionResult HomePageHero()
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

      HomepageModel.Homepage homePageModel = new HomepageModel.Homepage();

      //Multilist
      MultilistField heroListField = item.Fields[Templates.HomepageHero.Fields.HomepageHeroList];
      homePageModel.HeroSlides = PopulateHeroList(heroListField);


      return View(homePageModel);
    }
    public ActionResult TopCategoryRecipe()
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

      HomepageModel.Homepage homePageModel = new HomepageModel.Homepage();

      //Multilist
      MultilistField topCategoryRecipeListField = item.Fields[Templates.TopCategoryRecipe.Fields.TopCategoryRecipeList];
       Item[] recipeListItems = topCategoryRecipeListField.GetItems();
      List<Recipe> recipes = new List<Recipe>();

      if (recipeListItems != null && recipeListItems.Count() > 0)
      {
        foreach (Item recipeListItem in recipeListItems)
        {
          Recipe recipe = new Recipe();
          Item recipeItem = Sitecore.Context.Database.GetItem(recipeListItem.ID);
          recipe.RecipeName = recipeItem.Fields[Templates.Recipe.Fields.RecipName.ToString()].Value;


          recipe.RecipeAbscractText = recipeItem.Fields[Templates.Recipe.Fields.RecipeAbscractText.ToString()].Value;
        
          ImageField recipeImage = recipeItem.Fields[Templates.Recipe.Fields.RecipeAbscractImage];
          if(recipeImage!=null && recipeImage.MediaItem !=null)
            recipe.RecipeAbscractImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(recipeImage.MediaItem);


          recipe.RecipeURL = Sitecore.Links.LinkManager.GetItemUrl(recipeItem);
          //hero.HeroBackgroundImageUrlAlt = heroImage.Alt;

          recipes.Add(recipe);
        }

      }

      homePageModel.TopCategoryRecipe = recipes;

      return View(homePageModel);
    }

    public ActionResult BestRecipes()
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

      HomepageModel.Homepage homePageModel = new HomepageModel.Homepage();

      homePageModel.BestRecipesTitle = item.Fields[Templates.BestRecipes.Fields.BestRecipesTitle.ToString()].Value;


      //Multilist
      MultilistField bestRecipesListField = item.Fields[Templates.BestRecipes.Fields.BestRecipesList];
      Item[] bestRecipesListItems = bestRecipesListField.GetItems();
      List<Recipe> recipes = new List<Recipe>();

      if (bestRecipesListItems != null && bestRecipesListItems.Count() > 0)
      {
        foreach (Item recipeListItem in bestRecipesListItems)
        {
          Recipe recipe = new Recipe();
          Item recipeItem = Sitecore.Context.Database.GetItem(recipeListItem.ID);
          recipe.RecipeName = recipeItem.Fields[Templates.Recipe.Fields.RecipName.ToString()].Value;


          recipe.RecipeAbscractText = recipeItem.Fields[Templates.Recipe.Fields.RecipeAbscractText.ToString()].Value;

          ImageField recipeImage = recipeItem.Fields[Templates.Recipe.Fields.RecipeAbscractImage];
          if (recipeImage != null && recipeImage.MediaItem != null)
            recipe.RecipeAbscractImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(recipeImage.MediaItem);


          recipe.RecipeURL = Sitecore.Links.LinkManager.GetItemUrl(recipeItem);
          int rating = 0;
           int.TryParse( recipeItem.Fields[Templates.Recipe.Fields.RecipeRating.ToString()].Value,out rating);
          recipe.RecipeRating = rating;
          //hero.HeroBackgroundImageUrlAlt = heroImage.Alt;

          recipes.Add(recipe);
        }

      }

      homePageModel.BestRecipesList = recipes;

      return View(homePageModel);
    }
    public List<Hero> PopulateHeroList(MultilistField heroListField)
  {
    Item[] heroItems = heroListField.GetItems();
    List<Hero> heroSlides = new List<Hero>();



    if (heroItems != null && heroItems.Count() > 0)
    {
      foreach(Item heroSlideItem in heroItems)
      {
        Hero hero = new Hero();

          //Link - Droplink Field
          ReferenceField recipeLink = heroSlideItem.Fields[Templates.Hero.Fields.RecipeLink];
          Item recipeItem = recipeLink != null
            ?  recipeLink.TargetItem
            : null;


          Item heroItem = Sitecore.Context.Database.GetItem(heroSlideItem.ID);
          if (recipeItem != null)
          {

            hero.HeroTitle = recipeItem.Fields[Templates.Recipe.Fields.RecipName.ToString()].Value;
            ImageField heroImage = recipeItem.Fields[Templates.Recipe.Fields.RecipeAbscractImage];
            XmlDocument doc = new XmlDocument();
            //doc.LoadXml("<image stylelabs-content-id=\"29865\" thumbnailsrc=\"https://cmp-connector-400-r147.stylelabsqa.com/api/gateway/29865/thumbnail\" src=\"https://cmp-connector-400-r147.stylelabsqa.com/api/public/content/19c8d2004811433d931cc13c1d0b138a?v=638d2b04\" mediaid=\"\" stylelabs-content-type=\"Image\" alt=\"can-of-coke.jpg\" height=\"879\" width=\"1200\" />");
            doc.LoadXml(heroImage.Value);

            XmlElement root = doc.DocumentElement;

            string src = root.Attributes["src"] != null ? root.Attributes["src"].Value : string.Empty;

            if (string.IsNullOrEmpty(src))
            {
              if (heroImage != null && heroImage.MediaItem != null)
                hero.HeroBackgroundImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(heroImage.MediaItem);
              
            }
            else
            {
              hero.HeroBackgroundImageUrl = src;

            }
             

           

          }
          else
          {
            hero.HeroTitle = heroItem.Fields[Templates.Hero.Fields.HeroTitle.ToString()].Value;
            ImageField heroImage = heroItem.Fields[Templates.Hero.Fields.HeroBackgroundImage];
            hero.HeroBackgroundImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(heroImage.MediaItem);

          }
          hero.HeroSubtitle = heroItem.Fields[Templates.Hero.Fields.HeroSubtitle.ToString()].Value;
    
          hero.HomepageHeroCTALinkText = heroItem.Fields[Templates.Hero.Fields.HomepageHeroCTALinkText.ToString()].Value;
          
           LinkField HomepageHeroCTALink = heroItem.Fields[Templates.Hero.Fields.HomepageHeroCTALink.ToString()];

          if(HomepageHeroCTALink.LinkType.ToLower() =="internal" && HomepageHeroCTALink.TargetItem != null)
          {
            Item internalItem = Sitecore.Context.Database.GetItem(HomepageHeroCTALink.TargetID);
            hero.HomepageHeroCTALink = Sitecore.Links.LinkManager.GetItemUrl(internalItem);
          }
          else
          {
            hero.HomepageHeroCTALink = HomepageHeroCTALink.Url;
          }
          

          //hero.HeroBackgroundImageUrlAlt = heroImage.Alt;

          heroSlides.Add(hero);
          }
        
      }
    

    return heroSlides;
  }
}

}