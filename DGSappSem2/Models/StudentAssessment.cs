using AssessmentBusiness;
using DGSappSem2.Models.AssessmentBusiness;
using DGSappSem2.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models
{
    public class StudentAssessment  
    {
        [Key]
        public int StudentAssesmentID { get; set; }
        public int StID { get; set; }
        public virtual Student Student { get; set; }
        public int AssessmentID { get; set; }
        public virtual Assessment Assessment { get; set; }
        public int Mark { get; set; }

    }
}