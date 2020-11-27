
using AssessmentBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.ViewModel
{
    public class studentVM
    {
        public int StID { get; set; }
        public string StudentName { get; set; }

        public string StudentSurname { get; set; }

        public List<Term> termLists { get; set; }
    }
}