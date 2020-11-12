namespace DGSappSem2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo._Class", "ClassListID", "dbo.ClassLists");
            DropForeignKey("dbo.ClassLists", "StID", "dbo.Students");
            DropForeignKey("dbo._Class", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.Course_Material", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo._Class", "SubjectID", "dbo._Subject");
            DropForeignKey("dbo.Course_Material", "SubjectID", "dbo._Subject");
            DropForeignKey("dbo.SubjectReports", "SubjectID", "dbo._Subject");
            DropIndex("dbo._Class", new[] { "SubjectID" });
            DropIndex("dbo._Class", new[] { "ClassListID" });
            DropIndex("dbo._Class", new[] { "StaffID" });
            DropIndex("dbo.ClassLists", new[] { "StID" });
            DropIndex("dbo.Course_Material", new[] { "SubjectID" });
            DropIndex("dbo.Course_Material", new[] { "StaffId" });
            DropIndex("dbo.SubjectReports", new[] { "SubjectID" });
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        ClassRoomID = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        RoomNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassRoomID);
            
            CreateTable(
                "dbo.StudentClassRooms",
                c => new
                    {
                        StudentClassRoomID = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        ClassRoomID = c.Int(nullable: false),
                        StID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentClassRoomID)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StID, cascadeDelete: true)
                .Index(t => t.ClassRoomID)
                .Index(t => t.StID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        RequiredPercentage = c.Int(nullable: false),
                        ClassRoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomID, cascadeDelete: true)
                .Index(t => t.ClassRoomID);
            
            DropTable("dbo._Class");
            DropTable("dbo.ClassLists");
            DropTable("dbo.Course_Material");
            DropTable("dbo._Subject");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo._Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.Course_Material",
                c => new
                    {
                        CourseMaterialID = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50),
                        SubjectID = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseMaterialID);
            
            CreateTable(
                "dbo.ClassLists",
                c => new
                    {
                        ClassListID = c.Int(nullable: false, identity: true),
                        StID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassListID);
            
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
                .PrimaryKey(t => t.ClassID);
            
            DropForeignKey("dbo.Subjects", "ClassRoomID", "dbo.ClassRooms");
            DropForeignKey("dbo.StudentClassRooms", "StID", "dbo.Students");
            DropForeignKey("dbo.StudentClassRooms", "ClassRoomID", "dbo.ClassRooms");
            DropIndex("dbo.Subjects", new[] { "ClassRoomID" });
            DropIndex("dbo.StudentClassRooms", new[] { "StID" });
            DropIndex("dbo.StudentClassRooms", new[] { "ClassRoomID" });
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentClassRooms");
            DropTable("dbo.ClassRooms");
            CreateIndex("dbo.SubjectReports", "SubjectID");
            CreateIndex("dbo.Course_Material", "StaffId");
            CreateIndex("dbo.Course_Material", "SubjectID");
            CreateIndex("dbo.ClassLists", "StID");
            CreateIndex("dbo._Class", "StaffID");
            CreateIndex("dbo._Class", "ClassListID");
            CreateIndex("dbo._Class", "SubjectID");
            AddForeignKey("dbo.SubjectReports", "SubjectID", "dbo._Subject", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.Course_Material", "SubjectID", "dbo._Subject", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo._Class", "SubjectID", "dbo._Subject", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.Course_Material", "StaffId", "dbo.Staffs", "StaffId", cascadeDelete: true);
            AddForeignKey("dbo._Class", "StaffID", "dbo.Staffs", "StaffId", cascadeDelete: true);
            AddForeignKey("dbo.ClassLists", "StID", "dbo.Students", "StID", cascadeDelete: true);
            AddForeignKey("dbo._Class", "ClassListID", "dbo.ClassLists", "ClassListID", cascadeDelete: true);
        }
    }
}
