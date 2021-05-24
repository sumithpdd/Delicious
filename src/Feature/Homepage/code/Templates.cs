using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Delicious.Feature.Homepage
{
  public static class Templates
  {
    public static class HomepageTwoColumnCTA
    {
      public static class Fields
      {
        public static readonly ID Column1Title = new ID("{D41B65C8-8BB0-4617-945F-FACC66A83A20}");
        public static readonly ID Column1Text = new ID("{A1F6E265-E0CE-4A44-BC9D-FCC2CBF19E79}");
        public static readonly ID Column1Link = new ID("{FD5783B4-F6C6-47A6-AA30-45D7936DCC98}");
        public static readonly ID Column1Image = new ID("{D3FCB1FA-A933-4EFE-B1AC-5F81AAD24FB6}");
        public static readonly ID Column2Title = new ID("{D46C5EBF-F005-4416-8157-49C1947BB026}");
        public static readonly ID Column2Text = new ID("{3A4EACDC-D115-4F22-8E4C-C2B3EB331C9B}");
        public static readonly ID Column2Link = new ID("{31D7D3D7-E912-49D1-B733-8F7DB4EF4865}");
        public static readonly ID Column2Image = new ID("{9912A396-CA66-497F-8B2D-6E2BF60F8BEA}");
      }
    }

    public static class HomepageCTA
    {
      public static class Fields
      {
        public static readonly ID CTABackgroundImage = new ID("{74BE8A5A-9018-4EFA-B3C8-175D0B75FE55}");
        public static readonly ID CTATitle = new ID("{D1A19ABA-8488-4FF2-9432-1FF42F96A333}");
        public static readonly ID CTAText = new ID("{B5FA4118-83FD-48E7-AA0E-D2EE69AD9136}");
        public static readonly ID CTALink = new ID("{2740BFD4-6E0D-4099-A044-B29D6EF2C3DF}");        
      }
    }
    public static class HomepageHero
    {
      public static class Fields
      {

        public static readonly ID HomepageHeroList = new ID("{EE42A785-3D78-4E89-A96B-68D66D35B459}");


      }
    }
   

   
    public static class Hero
    {
      public static class Fields
      {
        public static readonly ID HeroBackgroundImage = new ID("{D8B32A62-7CD4-4AFB-89D6-A3E3A97C4632}");
        public static readonly ID HeroTitle = new ID("{21625D95-4C9E-458C-9436-7588E444A99E}");
        public static readonly ID HeroSubtitle = new ID("{1F7BA84F-C51E-4E00-97BB-6AF81226E099}");
        public static readonly ID HomepageHeroCTALink = new ID("{48B24967-7AE3-48BE-BC6E-D2415D4797FF}");
        public static readonly ID HomepageHeroCTALinkText = new ID("{D6B08588-FFBB-400D-BC84-854D48432AE9}");

      }
    }
    public static class TopCategoryRecipe
    {
      public static class Fields
      {

        public static readonly ID TopCategoryRecipeList = new ID("{65C9F672-15AF-40AA-B754-0C4D2AA817BB}");


      }
    }
    public static class BestRecipes
    {
      public static class Fields
      {

        
          public static readonly ID BestRecipesTitle = new ID("{1243D636-FB7A-4C91-A1FE-606C98D2EF82}");
        public static readonly ID BestRecipesList = new ID("{21865EFB-B5CB-4E61-9520-3CB18DF9BA3A}");


      }
    }

    
    public static class Recipe
    {
      public static class Fields
      {
        public static readonly ID RecipName = new ID("{FF50CBDF-5C0F-414D-88C7-BEDD53FFAFA7}");
        public static readonly ID RecipeAbscractText = new ID("{3528E16C-0AA6-43A5-8016-772509E86B60}");
        public static readonly ID RecipeAbscractImage = new ID("{37F5C38C-C65B-471C-BA05-45D89E9068BC}");
        public static readonly ID RecipeRating = new ID("{0B119B18-6837-435A-AE8E-440F1F4CBCDE}");
      }
    }

  }
}