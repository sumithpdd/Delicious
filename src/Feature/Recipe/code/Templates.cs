using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Delicious.Feature.Recipes
{
  public struct Templates
  {
    public static class Recipe
    {
      public static class Fields
      {
        public static readonly ID RecipeName = new ID("{FF50CBDF-5C0F-414D-88C7-BEDD53FFAFA7}");

        public static readonly ID RecipeDate = new ID("{A7C1C9F9-A5CD-474B-B55E-94A9639AA769}");
        public static readonly ID RecipeId = new ID("{9853877B-111D-42F8-8249-EF0147FF3BD9}");
   public static readonly ID RecipeDescription = new ID("{5674CCAC-D31C-4B93-A524-417754CD6813}");
     
        public static readonly ID RecipeType = new ID("{F329E9D8-A72B-4610-BBA0-7DA76C8FAA9F}");
        public static readonly ID ChefAuthor = new ID("{2FF20AFA-3462-4B2E-82E1-38263022A322}");
        public static readonly ID CookingTime = new ID("{A601B795-D890-47A9-BA42-2A539074A3DC}");
        public static readonly ID PreperationTime = new ID("{ED908441-F6BC-4BE6-B90F-6A070EDF07BF}");
        public static readonly ID PreparationMethod = new ID("{78056BC1-061D-49B9-92E7-A789930D320C}");
        public static readonly ID MainIngredients = new ID("{061567CB-183B-44CA-867A-2BD47B763EAB}");

        public static readonly ID RecipeImage = new ID("{5D009D7E-30C3-4770-BA05-750D4241BF36}");
        public static readonly ID RecipeHeroImage = new ID("{46D2E68F-6128-425D-A3BA-2DD3EFE9279A}");

        public static readonly ID RecipeRating = new ID("{0B119B18-6837-435A-AE8E-440F1F4CBCDE}");

        public static readonly ID RecipeDifficulty = new ID("{D7E477C1-201E-4890-B789-75E4D6F05C6F}");
        public static readonly ID RecipeServes = new ID("{41FB57A9-4646-4B7C-9248-23C323E1B022}");

        public static readonly ID RecipeAbscractText = new ID("{3528E16C-0AA6-43A5-8016-772509E86B60}");
        public static readonly ID RecipeAbscractImage = new ID("{37F5C38C-C65B-471C-BA05-45D89E9068BC}");
       }
    }

    public static class LatestRecipes
    {
      public static class Fields
      {
        public static readonly ID LatestRecipesTitle = new ID("{136A0B0F-7DB7-41B4-9352-83F016CF2AB2}");
        public static readonly ID LatestRecipesText = new ID("{004AD12F-26B7-4DE2-84D4-B44CFF562C7F}");
         public static readonly ID LatestRecipesInformationText = new ID("{9735EFCA-5391-4258-959E-AFD144C0A3D3}");
        public static readonly ID LatestRecipesList = new ID("{6F2F3C31-C65D-4F8E-A516-2477A8BF8F96}");

      }
    }
    public static class FeaturedRecipe
    {
      public static class Fields
      {
        public static readonly ID FeaturedRecipesTitle = new ID("{136A0B0F-7DB7-41B4-9352-83F016CF2AB2}");
        public static readonly ID FeaturedRecipesText = new ID("{004AD12F-26B7-4DE2-84D4-B44CFF562C7F}");
        public static readonly ID FeaturedRecipe = new ID("{6F2F3C31-C65D-4F8E-A516-2477A8BF8F96}");
        public static readonly ID FeaturedRecipesList = new ID("{165D2CF2-D3BA-4033-9401-A4463BAAB010}");
      }
    }
    public static class Event
    {
      public static class Fields
      {
        public static readonly ID EventName = new ID("{987747E5-0E68-485F-9BE9-01DA36FAB624}");
        public static readonly ID EventDate = new ID("{F5167D16-A419-43D9-8A18-CE16AB1E3C5D}");
        public static readonly ID IsFeaturedEvent = new ID("{BBCEA4F9-AAD6-45ED-B7E6-02E6A6AF8FCC}");
        public static readonly ID EventRecipes = new ID("{3E305C26-AB5C-4DBA-9396-1E4D1FDF4A05}");
      }
    }
  }
}