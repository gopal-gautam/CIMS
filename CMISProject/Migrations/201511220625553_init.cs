namespace CMISProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "CreatedByUserId", "dbo.User");
            DropForeignKey("dbo.Group", "CreateByUserId", "dbo.User");
            DropForeignKey("dbo.Message", "UserId", "dbo.User");
            DropForeignKey("dbo.Resource", "UserId", "dbo.User");
            DropForeignKey("dbo.InactiveUser", "UserId", "dbo.User");
            DropIndex("dbo.User", new[] { "CreatedByUserId" });
            DropIndex("dbo.Group", new[] { "CreateByUserId" });
            DropIndex("dbo.Message", new[] { "UserId" });
            DropIndex("dbo.Resource", new[] { "UserId" });
            DropIndex("dbo.InactiveUser", new[] { "UserId" });
            CreateTable(
                "dbo.GroupsUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Admin", "OrganizationName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Admin", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Admin", "CreatedBy", c => c.String());
            AddColumn("dbo.Admin", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Admin", "ModifiedBy", c => c.String());
            AddColumn("dbo.Group", "CreatedBy", c => c.String());
            AddColumn("dbo.Group", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Group", "ModifiedBy", c => c.String());
            AddColumn("dbo.User", "CreatedBy", c => c.String());
            AddColumn("dbo.User", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "ModifiedBy", c => c.String());
            AddColumn("dbo.Message", "CreatedBy", c => c.String());
            AddColumn("dbo.Message", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Message", "ModifiedBy", c => c.String());
            AddColumn("dbo.Resource", "UploadedBy", c => c.String());
            AddColumn("dbo.Resource", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Resource", "ModifiedBy", c => c.String());
            AddColumn("dbo.InactiveUser", "InactivatedBy", c => c.String());
            AddColumn("dbo.InactiveUser", "InactivatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Routine", "IssuedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Routine", "IssuedBy", c => c.String());
            AddColumn("dbo.Routine", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Routine", "ModifiedBy", c => c.String());
            AlterColumn("dbo.User", "UserId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Admin", "FirstName");
            DropColumn("dbo.Admin", "MiddleName");
            DropColumn("dbo.Admin", "LastName");
            DropColumn("dbo.Group", "CreateByUserId");
            DropColumn("dbo.User", "CreatedByUserId");
            DropColumn("dbo.Message", "UserId");
            DropColumn("dbo.Resource", "UserId");
            DropColumn("dbo.InactiveUser", "UserId");
            DropColumn("dbo.InactiveUser", "InactiveDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InactiveUser", "InactiveDate", c => c.String(nullable: false));
            AddColumn("dbo.InactiveUser", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Resource", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "CreatedByUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Group", "CreateByUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Admin", "LastName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Admin", "MiddleName", c => c.String(maxLength: 20));
            AddColumn("dbo.Admin", "FirstName", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.GroupsUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.GroupsUsers", "GroupId", "dbo.Group");
            DropIndex("dbo.GroupsUsers", new[] { "UserId" });
            DropIndex("dbo.GroupsUsers", new[] { "GroupId" });
            AlterColumn("dbo.User", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Routine", "ModifiedBy");
            DropColumn("dbo.Routine", "ModifiedDate");
            DropColumn("dbo.Routine", "IssuedBy");
            DropColumn("dbo.Routine", "IssuedDate");
            DropColumn("dbo.InactiveUser", "InactivatedDate");
            DropColumn("dbo.InactiveUser", "InactivatedBy");
            DropColumn("dbo.Resource", "ModifiedBy");
            DropColumn("dbo.Resource", "ModifiedDate");
            DropColumn("dbo.Resource", "UploadedBy");
            DropColumn("dbo.Message", "ModifiedBy");
            DropColumn("dbo.Message", "ModifiedDate");
            DropColumn("dbo.Message", "CreatedBy");
            DropColumn("dbo.User", "ModifiedBy");
            DropColumn("dbo.User", "ModifiedDate");
            DropColumn("dbo.User", "CreatedBy");
            DropColumn("dbo.Group", "ModifiedBy");
            DropColumn("dbo.Group", "ModifiedDate");
            DropColumn("dbo.Group", "CreatedBy");
            DropColumn("dbo.Admin", "ModifiedBy");
            DropColumn("dbo.Admin", "ModifiedDate");
            DropColumn("dbo.Admin", "CreatedBy");
            DropColumn("dbo.Admin", "CreatedDate");
            DropColumn("dbo.Admin", "OrganizationName");
            DropTable("dbo.GroupsUsers");
            CreateIndex("dbo.InactiveUser", "UserId");
            CreateIndex("dbo.Resource", "UserId");
            CreateIndex("dbo.Message", "UserId");
            CreateIndex("dbo.Group", "CreateByUserId");
            CreateIndex("dbo.User", "CreatedByUserId");
            AddForeignKey("dbo.InactiveUser", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Resource", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Message", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Group", "CreateByUserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.User", "CreatedByUserId", "dbo.User", "UserId");
        }
    }
}
