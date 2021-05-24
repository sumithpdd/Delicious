using Delicious.Feature.Recipes.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delicious.Feature.Recipes.Helpers
{
  public class EventHelpers
  {
    public List<Event> PopulateEventList(MultilistField eventListField)
    {
      Item[] eventItems = eventListField.GetItems();
      List<Event> eventList = new List<Event>();
      if (eventItems != null && eventItems.Count() > 0)
      {
        foreach (Item ev in eventItems)
        {
          Event e = new Event();
          Item eventItem = Sitecore.Context.Database.GetItem(ev.ID);
          e.EventName = eventItem.Fields[Templates.Event.Fields.EventName.ToString()].Value;
          CheckboxField isFeaturedEventField = eventItem.Fields[Templates.Event.Fields.IsFeaturedEvent];
          e.IsFeaturedEvent = isFeaturedEventField.Checked;
          DateField eventDateField = eventItem.Fields[Templates.Event.Fields.EventDate];
          e.EventDate = eventDateField.DateTime.ToLocalTime();
          e.EventDateString = eventDateField.DateTime.ToLocalTime().ToString("f");
          e.EventTimeString = eventDateField.DateTime.ToLocalTime().ToString("t");

          //TreelistEx
          MultilistField eventRecipesField = eventItem.Fields[Templates.Event.Fields.EventRecipes];
          Item[] eventRecipeItems = eventRecipesField.GetItems();
          List<Recipe> eventRecipeList = new List<Recipe>();
          if (eventRecipeItems != null && eventRecipeItems.Count() > 0)
          {
            foreach (Item sp in eventRecipeItems)
            {
              Recipe Recipe = new Recipe();
              Item RecipeItem = Sitecore.Context.Database.GetItem(sp.ID);
              Recipe.RecipeName = RecipeItem.Fields[Templates.Recipe.Fields.RecipeName.ToString()].Value;
              ImageField RecipeImage = RecipeItem.Fields[Templates.Recipe.Fields.RecipeImage];
              Recipe.RecipeImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(RecipeImage.MediaItem);
              Recipe.RecipeImageAlt = RecipeImage.Alt;

              eventRecipeList.Add(Recipe);
            }

            e.EventRecipes = eventRecipeList;
          }

          eventList.Add(e);
        }
      }

      return eventList;
    }

    public Recipe GetFeaturedRecipe(Item item)
    {
      Recipe featuredRecipe = new Recipe();

      Item featuredRecipeItem = Sitecore.Context.Database.GetItem(item.ID);
      if (featuredRecipeItem != null)
      {
        }

      return featuredRecipe;
    }
  }
}
