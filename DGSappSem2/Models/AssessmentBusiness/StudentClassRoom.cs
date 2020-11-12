using DGSappSem2.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentBusiness
{
    public class StudentClassRoom
    {
         [Key]
        public int StudentClassRoomID { get; set; }
        public DateTime DateCreated { get; set; }
        public int ClassRoomID { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public int StID { get; set; }
        public virtual Student Student { get; set; }

    }
}
