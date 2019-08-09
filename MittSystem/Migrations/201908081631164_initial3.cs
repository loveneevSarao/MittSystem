namespace MittSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
  
            CreateTable(
                "dbo.ApplicationUserCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            AddColumn("dbo.Courses", "Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "Credits", c => c.Int(nullable: false));
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserCourses",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Course_Id });
            
            DropForeignKey("dbo.ApplicationUserCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserCourses", new[] { "CourseId" });
            DropColumn("dbo.Courses", "Credits");
            DropColumn("dbo.Courses", "Capacity");
            DropTable("dbo.ApplicationUserCourses");
            CreateIndex("dbo.ApplicationUserCourses", "Course_Id");
            AddForeignKey("dbo.ApplicationUserCourses", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
