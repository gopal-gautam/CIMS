namespace CMISProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Group", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.User", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Message", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Resource", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Routine", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Routine", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Resource", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Message", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.User", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Group", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
