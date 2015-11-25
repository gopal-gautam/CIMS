namespace CMISProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resource", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.GroupResource", "ResourceId", "dbo.Resource");
            DropForeignKey("dbo.UserResource", "ResourceId", "dbo.Resource");
            DropIndex("dbo.Resource", new[] { "SubjectId" });
            DropIndex("dbo.GroupResource", new[] { "ResourceId" });
            DropIndex("dbo.UserResource", new[] { "ResourceId" });
            RenameColumn(table: "dbo.Faculty", name: "UserId", newName: "FacultyHeadId");
            RenameColumn(table: "dbo.GroupResource", name: "ResourceId", newName: "ResourceName");
            RenameColumn(table: "dbo.UserResource", name: "ResourceId", newName: "ResourceName");
            CreateTable(
                "dbo.MessageReaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        React = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Message", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MessageId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Message", "Attachment_ResourceName", c => c.String(maxLength: 128));
            AlterColumn("dbo.GroupResource", "ResourceName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Resource", "ResourceType", c => c.Int());
            AlterColumn("dbo.Resource", "ResourceName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Resource", "SubjectId", c => c.Int());
            AlterColumn("dbo.UserResource", "ResourceName", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Resource");
            AddPrimaryKey("dbo.Resource", "ResourceName");
            CreateIndex("dbo.Message", "Attachment_ResourceName");
            CreateIndex("dbo.Resource", "SubjectId");
            CreateIndex("dbo.GroupResource", "ResourceName");
            CreateIndex("dbo.UserResource", "ResourceName");
            AddForeignKey("dbo.Message", "Attachment_ResourceName", "dbo.Resource", "ResourceName");
            AddForeignKey("dbo.Resource", "SubjectId", "dbo.Subject", "SubjectId");
            AddForeignKey("dbo.GroupResource", "ResourceName", "dbo.Resource", "ResourceName", cascadeDelete: true);
            AddForeignKey("dbo.UserResource", "ResourceName", "dbo.Resource", "ResourceName", cascadeDelete: true);
            DropColumn("dbo.Message", "Attachment");
            DropColumn("dbo.Message", "React");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "React", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "Attachment", c => c.String());
            DropForeignKey("dbo.UserResource", "ResourceName", "dbo.Resource");
            DropForeignKey("dbo.GroupResource", "ResourceName", "dbo.Resource");
            DropForeignKey("dbo.Resource", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.MessageReaction", "UserId", "dbo.User");
            DropForeignKey("dbo.MessageReaction", "MessageId", "dbo.Message");
            DropForeignKey("dbo.Message", "Attachment_ResourceName", "dbo.Resource");
            DropIndex("dbo.UserResource", new[] { "ResourceName" });
            DropIndex("dbo.GroupResource", new[] { "ResourceName" });
            DropIndex("dbo.Resource", new[] { "SubjectId" });
            DropIndex("dbo.MessageReaction", new[] { "UserId" });
            DropIndex("dbo.MessageReaction", new[] { "MessageId" });
            DropIndex("dbo.Message", new[] { "Attachment_ResourceName" });
            DropPrimaryKey("dbo.Resource");
            AddPrimaryKey("dbo.Resource", "ResourceId");
            AlterColumn("dbo.UserResource", "ResourceName", c => c.Int(nullable: false));
            AlterColumn("dbo.Resource", "SubjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Resource", "ResourceName", c => c.String(nullable: false));
            AlterColumn("dbo.Resource", "ResourceType", c => c.Int(nullable: false));
            AlterColumn("dbo.GroupResource", "ResourceName", c => c.Int(nullable: false));
            DropColumn("dbo.Message", "Attachment_ResourceName");
            DropTable("dbo.MessageReaction");
            RenameColumn(table: "dbo.UserResource", name: "ResourceName", newName: "ResourceId");
            RenameColumn(table: "dbo.GroupResource", name: "ResourceName", newName: "ResourceId");
            RenameColumn(table: "dbo.Faculty", name: "FacultyHeadId", newName: "UserId");
            CreateIndex("dbo.UserResource", "ResourceId");
            CreateIndex("dbo.GroupResource", "ResourceId");
            CreateIndex("dbo.Resource", "SubjectId");
            AddForeignKey("dbo.UserResource", "ResourceId", "dbo.Resource", "ResourceId", cascadeDelete: true);
            AddForeignKey("dbo.GroupResource", "ResourceId", "dbo.Resource", "ResourceId", cascadeDelete: true);
            AddForeignKey("dbo.Resource", "SubjectId", "dbo.Subject", "SubjectId", cascadeDelete: true);
        }
    }
}
