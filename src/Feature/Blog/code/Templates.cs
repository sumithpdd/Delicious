using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Delicious.Feature.Blog
{
  public struct Templates
  {
    public static class Blog
    {
      public static class Fields
      {
        public static readonly ID BlogHeadline = new ID("{5DEDA9B5-36EA-48DC-A68B-87C0C9487501}");
        public static readonly ID BlogDate = new ID("{E7F6A6CD-0CE2-4E8E-9DF0-1FF893059D1F}");
        public static readonly ID BlogHeadlineImage = new ID("{F14ED3EF-DBBA-4820-BAE4-27861B3F3C30}");
        public static readonly ID BlogByline = new ID("{53A98AC1-F3C4-4D34-BECF-1192DBBC0EE4}");
        public static readonly ID BlogBodyCopy = new ID("{2D456221-BA6D-448B-878E-69B0C5A8620C}");
        public static readonly ID BlogRecipes = new ID("{2E8282BE-7630-4D8A-8BE1-6380090F2D2E}");
        public static readonly ID BlogAuthor = new ID("{81C9DEB0-599D-4AB7-A72C-6C837F1C05A8}");
        
        
      }
    }
    public static class Recipe
    {
      public static class Fields
      {
        public static readonly ID RecipeName = new ID("{0B9D42C9-0704-45D3-AC29-0C4E65616E0A}");
        public static readonly ID RecipeTitle = new ID("{E5F6B2FB-4CCF-43D5-8238-7A247EBFF403}");
        public static readonly ID RecipeImage = new ID("{15F42F66-9EC6-44E1-8B65-39A61AE704CC}");
        public static readonly ID RecipeDescription = new ID("{D628FB26-37BD-4E8C-B8DE-99C78023B349}");
        public static readonly ID RecipeTwitterUrl = new ID("{DB84959B-20DF-4371-A5D3-77A221B3E7BC}");
        public static readonly ID RecipeLinkedInUrl = new ID("{B5A3C8E7-F756-4072-87DA-DCB716C0AA0E}");
        public static readonly ID RecipeWebsiteUrl = new ID("{9FB095EA-E113-4A5F-9F31-68DAF0C646AD}");
      }
    }
  }
}