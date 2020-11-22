
namespace DGSappSem2.Models.ViewModel
{
    public class AssessmentVM
    {
        public int AssessmentID { get; set; }
        public string AssessmentName { get; set; }
        public int ContributionPercent { get; set; }
        public int TermID { get; set; }
        public int TotalMark { get; set; }
        public int ActualMark { get; set; }
        public int SubjectID { get; set; }
    }
}