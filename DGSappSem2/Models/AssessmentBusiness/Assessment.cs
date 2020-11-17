using DGSappSem2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssessmentBusiness
{
    public class Assessment
    {
        [Key]
        public int AssessmentID { get; set; }
        public string AssessmentName { get; set; }
        public int ContributionPercent { get; set; }
        public int TermID { get; set; }
        public virtual Term Term { get; set; }
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
        public int TotalMark { get; set; }

        public virtual ICollection<StudentAssessment> StudentAssessments { get; set; }
    }
}