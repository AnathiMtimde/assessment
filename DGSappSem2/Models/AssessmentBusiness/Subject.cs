using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentBusiness
{
   public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int RequiredPercentage { get; set; }
        public int ClassRoomID { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public virtual ICollection <Assessment> Assessments { get; set; }
    }
}
