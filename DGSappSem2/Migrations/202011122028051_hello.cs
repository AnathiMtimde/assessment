namespace DGSappSem2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "AssessmentId", "dbo.Assessments");
            DropForeignKey("dbo.SubjectReports", "Assessments_AssessmentID", "dbo.Assessments");
            DropIndex("dbo.Reports", new[] { "AssessmentId" });
            DropIndex("dbo.SubjectReports", new[] { "Assessments_AssessmentID" });
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        TermID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TermID);
            
            AddColumn("dbo.Assessments", "AssessmentName", c => c.String());
            AddColumn("dbo.Assessments", "ContributionPercent", c => c.String());
            AddColumn("dbo.Assessments", "TermID", c => c.Int(nullable: false));
            AddColumn("dbo.Assessments", "SubjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Assessments", "TermID");
            CreateIndex("dbo.Assessments", "SubjectID");
            AddForeignKey("dbo.Assessments", "SubjectID", "dbo.Subjects", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.Assessments", "TermID", "dbo.Terms", "TermID", cascadeDelete: true);
            DropColumn("dbo.Assessments", "Grade");
            DropColumn("dbo.Assessments", "StartTime");
            DropColumn("dbo.Assessments", "EndTime");
            DropColumn("dbo.Assessments", "AssessmentDate");
            DropColumn("dbo.Assessments", "AssessmentVenue");
            DropColumn("dbo.Assessments", "Term");
            DropColumn("dbo.Assessments", "Type");
            DropColumn("dbo.Reports", "AssessmentId");
            DropColumn("dbo.SubjectReports", "AssesssmentId");
            DropColumn("dbo.SubjectReports", "Assessments_AssessmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectReports", "Assessments_AssessmentID", c => c.Int());
            AddColumn("dbo.SubjectReports", "AssesssmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Reports", "AssessmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Assessments", "Type", c => c.String(nullable: false));
            AddColumn("dbo.Assessments", "Term", c => c.String(nullable: false));
            AddColumn("dbo.Assessments", "AssessmentVenue", c => c.String(nullable: false));
            AddColumn("dbo.Assessments", "AssessmentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assessments", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assessments", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assessments", "Grade", c => c.String(nullable: false));
            DropForeignKey("dbo.Assessments", "TermID", "dbo.Terms");
            DropForeignKey("dbo.Assessments", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.Assessments", new[] { "SubjectID" });
            DropIndex("dbo.Assessments", new[] { "TermID" });
            DropColumn("dbo.Assessments", "SubjectID");
            DropColumn("dbo.Assessments", "TermID");
            DropColumn("dbo.Assessments", "ContributionPercent");
            DropColumn("dbo.Assessments", "AssessmentName");
            DropTable("dbo.Terms");
            CreateIndex("dbo.SubjectReports", "Assessments_AssessmentID");
            CreateIndex("dbo.Reports", "AssessmentId");
            AddForeignKey("dbo.SubjectReports", "Assessments_AssessmentID", "dbo.Assessments", "AssessmentID");
            AddForeignKey("dbo.Reports", "AssessmentId", "dbo.Assessments", "AssessmentID", cascadeDelete: true);
        }
    }
}
