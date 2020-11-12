using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace DGSappSem2.Models.Events
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int eventID { get; set; }
        [Display(Name = "Event Name")]
        public string eventName { get; set; }
        [Display(Name = "Email Address")]
        //   public string emailAddress { get; set; }
        public string venueId { get; set; }
        public virtual Venue Venue { get; set; }
        [Display(Name = "Event Price"), DataType(DataType.Currency)]
        public decimal? BookingPrice { get; set; }


        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime eventDate { get; set; }
        [DisplayName("Event Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime eventStartTime { get; set; }
        [Display(Name = "Event Finish Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime eventEndTime { get; set; }
        public ICollection<BookEvent> BookEvents { get; set; }

        // ApplicationDbContext db = new ApplicationDbContext();
        //public bool CHeckTime()
        //{

        //    bool result = false;
        //    var record = db.Event.ToList();
        //    foreach (var item in record)
        //    {
        //        if ((eventStartTime >= item.eventStartTime) && (eventStartTime <= item.eventEndTime) && (eventDate == item.eventDate) && (venueId == item.venueId))
        //        {
        //            result = true;
        //        }
        //    }
        //    return result;
        //}

        //public bool dateChecker(DateTime eventDate, DateTime startTimes, DateTime endTimes, string venueID)
        //{

        //    bool check = false;
        //    var outDate = (from r in db.events
        //                   where r.venueId == venueID
        //                   select r.eventDate
        //     ).FirstOrDefault();

        //    var VenueID = (from r in db.Event
        //                   where r.venueId == venueID
        //                   select r.venueId
        //    ).FirstOrDefault();

        //    var startTime = (from r in db.events
        //                     where r.venueId == venueID
        //                     select r.eventStartTime
        //     ).FirstOrDefault();

        //    var EndTime = (from r in db.events
        //                   where r.venueId == venueID
        //                   select r.eventEndTime
        //         ).FirstOrDefault();

        //    if (eventDate == outDate && startTimes >= startTime && startTimes <= EndTime /*&& endTimes <=startTimes*/ && venueID == VenueID)
        //    {
        //        check = true;
        //    }
        //    return check;
        //}

        //public bool Time()
        //{

        //    bool result = false;
        //    var record = db.events.ToList();
        //    foreach (var item in record)
        //    {
        //        if ((eventDate.Year < DateTime.Now.Year))
        //        {
        //            result = true;
        //        }
        //    }
        //    return result;
        //}

    }
}
