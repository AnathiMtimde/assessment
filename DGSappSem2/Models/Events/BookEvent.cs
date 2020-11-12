using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DGSappSem2.Models.Events
{
    public class BookEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookEventId { get; set; }


        [Display(Name = "Number Of Ocupants"), Required]
        public int Quantiy { get; set; }
        //[Display(Name = "Number of participants")]
        //public int numParticipant { get; set; }
        public string RefNum { get; internal set; }

        [Display(Name = "Date Booking For"), DataType(DataType.Date), Required]
        public DateTime DateBookinFor { get; set; }
        public bool CheckDate()
        {
            bool result = false;

            if (DateBookinFor == DateTime.Now || DateBookinFor < DateTime.Now.Date)
            {
                result = true;
            }
            return result;
        }

        //public int venueID { get; set; }
        //public virtual Venue Venue { get; set; }





        ApplicationDbContext db = new ApplicationDbContext();

        public int eventID;
        // linq to get Event price 
        public decimal? getEventPrice()
        {
            var prc = (from V in db.Events
                       where eventID == V.eventID
                       select V.BookingPrice).FirstOrDefault();
            return prc;
        }

        public int StudentID;

        // linq to get Event price 
        public string getStudentEmail()
        {
            var stuEmail = (from V in db.students
                            where StudentID == V.StID
                            select V.StudentEmail).FirstOrDefault();
            return stuEmail;
        }


    }
}
