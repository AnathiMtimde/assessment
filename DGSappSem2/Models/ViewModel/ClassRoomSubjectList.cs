using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.ViewModel
{
    public class ClassRoomSubjectList
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public List<TermList> TermLists { get; set; }
    }
}