namespace CMISProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Routine", "UserId", "dbo.User");
            DropIndex("dbo.Routine", new[] { "UserId" });
            CreateTable(
                "dbo.Period",
                c => new
                    {
                        PeriodId = c.Int(nullable: false, identity: true),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        TeacherUserId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        BreakRemark = c.Int(nullable: false),
                        Routine_RoutineId = c.Int(),
                    })
                .PrimaryKey(t => t.PeriodId)
                .ForeignKey("dbo.User", t => t.TeacherUserId, cascadeDelete: true)
                .ForeignKey("dbo.Routine", t => t.Routine_RoutineId)
                .Index(t => t.TeacherUserId)
                .Index(t => t.Routine_RoutineId);
            
            DropColumn("dbo.Routine", "StartTime");
            DropColumn("dbo.Routine", "EndTime");
            DropColumn("dbo.Routine", "UserId");
            DropColumn("dbo.Routine", "Day");
            DropColumn("dbo.Routine", "BreakRemark");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routine", "BreakRemark", c => c.Int(nullable: false));
            AddColumn("dbo.Routine", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.Routine", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Routine", "EndTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Routine", "StartTime", c => c.Time(nullable: false, precision: 7));
            DropForeignKey("dbo.Period", "Routine_RoutineId", "dbo.Routine");
            DropForeignKey("dbo.Period", "TeacherUserId", "dbo.User");
            DropIndex("dbo.Period", new[] { "Routine_RoutineId" });
            DropIndex("dbo.Period", new[] { "TeacherUserId" });
            DropTable("dbo.Period");
            CreateIndex("dbo.Routine", "UserId");
            AddForeignKey("dbo.Routine", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
