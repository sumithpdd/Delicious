using Delicious.Feature.Events.Models;
using Delicious.Feature.Events.Helpers;
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

namespace Delicious.Feature.Events.Controllers
{
  public class EventsController : Controller
  {
     

    public ActionResult EventSchedule()
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

      EventSchedule eventSchedule = new EventSchedule();

      //Background Image
      ImageField eventScheduleBackgroundImageField = item.Fields[Templates.EventSchedule.Fields.EventScheduleBackground];
      eventSchedule.EventScheduleBgImgUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(eventScheduleBackgroundImageField.MediaItem);

      EventHelpers helpers = new EventHelpers();

      //Multilist
      MultilistField day1EventsListField = item.Fields[Templates.EventSchedule.Fields.EventScheduleDay1Events];
      eventSchedule.EventScheduleDay1Events = helpers.PopulateEventList(day1EventsListField);

      //Date Field
      DateField day2DateField = item.Fields[Templates.EventSchedule.Fields.EventScheduleDay2Date];
      DateTime day2DateTime = day2DateField.DateTime;
      eventSchedule.EventScheduleDay2Date = day2DateTime.ToString("MMMM dd");

      //Multilist
      MultilistField day2EventsListField = item.Fields[Templates.EventSchedule.Fields.EventScheduleDay2Events];
      eventSchedule.EventScheduleDay2Events = helpers.PopulateEventList(day2EventsListField);

      return View(eventSchedule);
    }
  }
}