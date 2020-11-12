namespace DGSappSem2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assessments",
                c => new
                    {
                        AssessmentID = c.Int(nullable: false, identity: true),
                        Grade = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        AssessmentDate = c.DateTime(nullable: false),
                        AssessmentVenue = c.String(nullable: false),
                        Term = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AssessmentID);
            
            CreateTable(
                "dbo.BookEvents",
                c => new
                    {
                        BookEventId = c.Int(nullable: false, identity: true),
                        Quantiy = c.Int(nullable: false),
                        RefNum = c.String(),
                        DateBookinFor = c.DateTime(nullable: false),
                        Event_eventID = c.Int(),
                    })
                .PrimaryKey(t => t.BookEventId)
                .ForeignKey("dbo.Events", t => t.Event_eventID)
                .Index(t => t.Event_eventID);
            
            CreateTable(
                "dbo._Class",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                        SubjectID = c.Int(nullable: false),
                        ClassListID = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID)
                .ForeignKey("dbo.ClassLists", t => t.ClassListID, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: true)
                .ForeignKey("dbo._Subject", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.ClassListID)
                .Index(t => t.StaffID);
            
            CreateTable(
                "dbo.ClassLists",
                c => new
                    {
                        ClassListID = c.Int(nullable: false, identity: true),
                        StID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassListID)
                .ForeignKey("dbo.Students", t => t.StID, cascadeDelete: true)
                .Index(t => t.StID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        StudentSurname = c.String(nullable: false),
                        StudentGender = c.String(nullable: false),
                        StudentAddress = c.String(nullable: false),
                        StudentTown = c.String(nullable: false),
                        StudentContact = c.String(nullable: false),
                        StudentGrade = c.String(nullable: false),
                        StudentEmail = c.String(nullable: false),
                        StudentBirthCertURL = c.String(nullable: false),
                        StudentReportURL = c.String(nullable: false),
                        StudentProofResURL = c.String(nullable: false),
                        StudentPermitURL = c.String(),
                        StudentAllowReg = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        DateOfBirth = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Grade = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Position = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.Course_Material",
                c => new
                    {
                        CourseMaterialID = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50),
                        SubjectID = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseMaterialID)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .ForeignKey("dbo._Subject", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo._Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.SubjectReports",
                c => new
                    {
                        SubjectReportID = c.Int(nullable: false, identity: true),
                        SubjectID = c.Int(nullable: false),
                        AssesssmentId = c.Int(nullable: false),
                        Assessments_AssessmentID = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectReportID)
                .ForeignKey("dbo.Assessments", t => t.Assessments_AssessmentID)
                .ForeignKey("dbo._Subject", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.Assessments_AssessmentID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventID = c.Int(nullable: false, identity: true),
                        eventName = c.String(),
                        venueId = c.String(),
                        BookingPrice = c.Decimal(precision: 18, scale: 2),
                        eventDate = c.DateTime(nullable: false),
                        eventStartTime = c.DateTime(nullable: false),
                        eventEndTime = c.DateTime(nullable: false),
                        Venue_venueId = c.Int(),
                    })
                .PrimaryKey(t => t.eventID)
                .ForeignKey("dbo.Venues", t => t.Venue_venueId)
                .Index(t => t.Venue_venueId);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        venueId = c.Int(nullable: false, identity: true),
                        venueName = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        price = c.Decimal(precision: 18, scale: 2),
                        capacity = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.venueId);
            
            CreateTable(
                "dbo.FileUploadModels",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        File = c.Binary(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        marks = c.Int(nullable: false),
                        AssessmentId = c.Int(nullable: false),
                        Students_StID = c.Int(),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.Assessments", t => t.AssessmentId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Students_StID)
                .Index(t => t.AssessmentId)
                .Index(t => t.Students_StID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StaffAttendances",
                c => new
                    {
                        StaffAttendanceId = c.Int(nullable: false, identity: true),
                        StaffAttName = c.String(),
                        Staffrecord = c.String(),
                        GetDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StaffAttendanceId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reports", "Students_StID", "dbo.Students");
            DropForeignKey("dbo.Reports", "AssessmentId", "dbo.Assessments");
            DropForeignKey("dbo.Events", "Venue_venueId", "dbo.Venues");
            DropForeignKey("dbo.BookEvents", "Event_eventID", "dbo.Events");
            DropForeignKey("dbo.SubjectReports", "SubjectID", "dbo._Subject");
            DropForeignKey("dbo.SubjectReports", "Assessments_AssessmentID", "dbo.Assessments");
            DropForeignKey("dbo.Course_Material", "SubjectID", "dbo._Subject");
            DropForeignKey("dbo._Class", "SubjectID", "dbo._Subject");
            DropForeignKey("dbo.Course_Material", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo._Class", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.ClassLists", "StID", "dbo.Students");
            DropForeignKey("dbo._Class", "ClassListID", "dbo.ClassLists");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reports", new[] { "Students_StID" });
            DropIndex("dbo.Reports", new[] { "AssessmentId" });
            DropIndex("dbo.Events", new[] { "Venue_venueId" });
            DropIndex("dbo.SubjectReports", new[] { "Assessments_AssessmentID" });
            DropIndex("dbo.SubjectReports", new[] { "SubjectID" });
            DropIndex("dbo.Course_Material", new[] { "StaffId" });
            DropIndex("dbo.Course_Material", new[] { "SubjectID" });
            DropIndex("dbo.ClassLists", new[] { "StID" });
            DropIndex("dbo._Class", new[] { "StaffID" });
            DropIndex("dbo._Class", new[] { "ClassListID" });
            DropIndex("dbo._Class", new[] { "SubjectID" });
            DropIndex("dbo.BookEvents", new[] { "Event_eventID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StaffAttendances");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reports");
            DropTable("dbo.FileUploadModels");
            DropTable("dbo.Venues");
            DropTable("dbo.Events");
            DropTable("dbo.SubjectReports");
            DropTable("dbo._Subject");
            DropTable("dbo.Course_Material");
            DropTable("dbo.Staffs");
            DropTable("dbo.Students");
            DropTable("dbo.ClassLists");
            DropTable("dbo._Class");
            DropTable("dbo.BookEvents");
            DropTable("dbo.Assessments");
        }
    }
}
