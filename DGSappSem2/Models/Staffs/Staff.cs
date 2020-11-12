using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DGSappSem2.Models.Staffs
{

    public class Staff 
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Last name")]
        [Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Choose staff gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter date of birth")]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter phone number")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Enter Assigned class")]
        [Display(Name = "Grade")]
        public string Grade { get; set; }

        [Required(ErrorMessage = "Enter Assigned Subject")]
        [Display(Name = "Assigned Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Enter staff's home address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter staff's position")]
        public string Position { get; set; }

        //public int SubjectID { get; set; }
        //public virtual Subject Subjects { get; set; }

        //[Required(ErrorMessage = "Enter staff's salary")]
        //public string Salary { get; set; }

      

    }
}