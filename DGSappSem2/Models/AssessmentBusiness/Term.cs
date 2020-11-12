using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssessmentBusiness
{
    public class Term
    {
        [Key]
        public int TermID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }

    }
}