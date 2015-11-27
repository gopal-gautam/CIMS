namespace CMISProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Semester", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "UserId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User", "Guardian1Name", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Guardian1PhoneNumber", c => c.Long(nullable: false));
            DropColumn("dbo.User", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.User", "Guardian1PhoneNumber", c => c.Long());
            AlterColumn("dbo.User", "Guardian1Name", c => c.String());
            AlterColumn("dbo.User", "Semester", c => c.Int());
            AlterColumn("dbo.User", "UserId", c => c.Int());
        }
    }
}
