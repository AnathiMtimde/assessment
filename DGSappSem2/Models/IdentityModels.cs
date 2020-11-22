using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using DGSappSem2.Models.Staffs;
using DGSappSem2.Models.Students;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DGSappSem2.Models.Events;
using AssessmentBusiness;
using DGSappSem2.Models.AssessmentBusiness;

namespace DGSappSem2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public System.Data.Entity.DbSet<DGSappSem2.Models.FileUpload.FileUploadModel> fileUploadModel { get; set; }

        public DbSet<Student> students { get; set; }
        public DbSet<Staff> Staffs { get; set; }      
       
        //___________________Assessmentbusiness___________________
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<StudentClassRoom> StudentClassRooms { get; set; }

        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Term> Terms { get; set; }

        public DbSet<StudentAssessment> StudentAssessments { get; set; }
        
      
        //__________________AssessmentBusiness____________________
       

        //Event Database
        public DbSet<Event> Events { get; set; }
        public DbSet<BookEvent> BookEvents { get; set; }
        public DbSet<Venue> Venues { get; set; }

        public DbSet<StaffAttendance> StaffAttendances { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}