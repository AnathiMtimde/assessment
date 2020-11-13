using DGSappSem2.Models.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.AssessmentBusiness
{
    public class Report
    {
        public int ReportID { get; set; }
        public int StaffID { get; set; }
        public virtual Staff Staffs { get; set; }
        public int StudentAssessmentID { get; set; }
        public virtual StudentAssessment StudentAssessments { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string FinalStatus { get; set; }
    }
}