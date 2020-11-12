using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.Staffs
{
    public class StaffAttendance
    {
        [Key]
        public int StaffAttendanceId { get; set; }

        [Display(Name = "Name")]
        public string StaffAttName { get; set; }

        [Display(Name = "Clock In / Clock Out")]
        public string Staffrecord { get; set; }

        [Display(Name = "Time")]
        public DateTime GetDate { get; set; }
    }
}