using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.AssessmentBusiness
{
    public class StudentViewModel
    {
        public int StID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentGrade { get; set; }
        public bool SelectGrade { get; set; }

    }
}