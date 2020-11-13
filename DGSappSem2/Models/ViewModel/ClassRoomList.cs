using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models.ViewModel
{
    public class ClassRoomList
    {
        public int ClassRoomID { get; set; }
        public string GradeName { get; set; }

        public List<ClassRoomSubjectList> ClassRoomSubjectLists{get;set;}
    }
}