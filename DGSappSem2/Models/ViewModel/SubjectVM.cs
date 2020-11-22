using System.Collections.Generic;

namespace DGSappSem2.Models.ViewModel
{
    public class SubjectVM
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int RequirementPercentage { get; set; }
        public List<AssessmentVM> assessments { get; set; }
    }
    
}