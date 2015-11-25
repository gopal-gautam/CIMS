namespace CMISProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admin", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admin", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
