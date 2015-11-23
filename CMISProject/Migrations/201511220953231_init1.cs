namespace CMISProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admin", "PhoneNumbers", c => c.String());
            AddColumn("dbo.User", "PhoneNumber", c => c.String());
            AddColumn("dbo.Permission", "PermissionName", c => c.String());
            AddColumn("dbo.Permission", "PermissionDescription", c => c.String());
            DropColumn("dbo.Permission", "Perm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Permission", "Perm", c => c.String());
            DropColumn("dbo.Permission", "PermissionDescription");
            DropColumn("dbo.Permission", "PermissionName");
            DropColumn("dbo.User", "PhoneNumber");
            DropColumn("dbo.Admin", "PhoneNumbers");
        }
    }
}
