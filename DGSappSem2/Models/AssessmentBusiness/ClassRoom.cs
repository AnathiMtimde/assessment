using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentBusiness
{
   public class ClassRoom
    {
        [Key]
        public int ClassRoomID { get; set; }
        public string GradeName { get; set; }
        public int RoomNumber { get; set; }
        public virtual ICollection<StudentClassRoom> StudentClassRooms { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
