using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DGSappSem2.Models.Students;


namespace DGSappSem2.Models.Reports
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ReportID { get; set; }
        public int StudentID { get; set; }


        [Required(ErrorMessage = "Enter Marks")]
        [Display(Name = "Marks")]
        public int marks { get; set; }
        public Student Students { get; set; }

    
    }
}