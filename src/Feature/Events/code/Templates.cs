using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Delicious.Feature.Events
{
  public static class Templates
  {
   

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

    public static class EventSchedule
    {
      public static class Fields
      {
        public static readonly ID EventScheduleBackground = new ID("{8374BADF-B092-468E-B3A3-2F3B75BB2D22}");
        public static readonly ID EventScheduleTitle = new ID("{6C66E533-DB9B-487A-B660-DDE870F9C3D0}");
        public static readonly ID EventScheduleDay1Title = new ID("{2792206F-7AB3-4630-9BF4-F28CFF31252F}");
        public static readonly ID EventScheduleDay1Date = new ID("{D26FFAB7-9D1C-4D93-85D5-B7A5C11E5C43}");
        public static readonly ID EventScheduleDay1Location = new ID("{4B1321CA-7A2C-4AD6-8483-C15A44352139}");
        public static readonly ID EventScheduleDay1Events = new ID("{C7A352AA-E9A4-42F5-B44F-792D9E12387A}");
        public static readonly ID EventScheduleDay2Title = new ID("{30EA679A-9475-4248-A4E7-2F6F1EF1008A}");
        public static readonly ID EventScheduleDay2Date = new ID("{42D9F9B5-EF63-45D0-8DAD-74AE5B1399EE}");
        public static readonly ID EventScheduleDay2Location = new ID("{5E4512E1-BDBA-421E-A21A-FF79423B14A0}");
        public static readonly ID EventScheduleDay2Events = new ID("{DCCCB95E-ED83-4F1B-970E-45569D83C379}");
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