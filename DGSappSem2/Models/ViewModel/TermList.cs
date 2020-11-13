using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.ViewModel
{
    public class TermList
    {
        public int TermID { get; set; }
        public string Name { get; set; }

        public List<AssessmentList> AssessmentLists { get; set; }
    }
}