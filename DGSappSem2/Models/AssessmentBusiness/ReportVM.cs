using DGSappSem2.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace DGSappSem2.Models.AssessmentBusiness
{
    public class ReportVM
    {
        public int StID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string GradeName { get; set; }
        public string TermName { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public List<SubjectVM> subjectList { get; set; }
      
    }
}