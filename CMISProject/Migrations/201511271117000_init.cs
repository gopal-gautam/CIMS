namespace CMISProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 30),
                        OrganizationName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 30),
                        DateOfEstablishment = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        Email = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumbers = c.String(),
                        POBoxNumber = c.String(),
                        FaxNumber = c.String(),
                        PanNo = c.String(),
                        VatNo = c.String(),
                        LogoFile = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.CustomGroupProperty",
                c => new
                    {
                        CustomGroupPropertyId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Property = c.String(nullable: false),
                        Value = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomGroupPropertyId)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 30),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.CustomUserProperty",
                c => new
                    {
                        CustomUserPropertyId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Property = c.String(nullable: false),
                        Value = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomUserPropertyId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Sex = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        ImageFile = c.String(),
                        BloodGroup = c.Int(nullable: false),
                        CitizenShipNumber = c.String(),
                        Semester = c.Int(nullable: false),
                        Guardian1Name = c.String(nullable: false),
                        Guardian1PhoneNumber = c.Long(nullable: false),
                        Guardian2Name = c.String(),
                        Guardian2PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ExamMarkSheet",
                c => new
                    {
                        ExamMarkSheetId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Marks = c.Int(nullable: false),
                        ExamType = c.Int(nullable: false),
                        FullMarks = c.Int(nullable: false),
                        PassMarks = c.Int(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                        SubjectRank = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                        SemesterGradePointAverage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamMarkSheetId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false),
                        GroupId = c.Int(nullable: false),
                        SubjectTeacherId = c.Int(nullable: false),
                        CreditHours = c.Int(nullable: false),
                        PrimaryBook = c.String(nullable: false),
                        ReferenceBook1 = c.String(),
                        ReferenceBook2 = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.SubjectTeacherId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubjectTeacherId);
            
            CreateTable(
                "dbo.ExamRank",
                c => new
                    {
                        ExamRankId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TotalMarks = c.Int(nullable: false),
                        Percentage = c.Int(nullable: false),
                        Rank = c.Int(nullable: false),
                        SemesterGradePointAverage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamRankId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false),
                        FacultyHeadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId)
                .ForeignKey("dbo.User", t => t.FacultyHeadId, cascadeDelete: true)
                .Index(t => t.FacultyHeadId);
            
            CreateTable(
                "dbo.GroupMessage",
                c => new
                    {
                        GroupMessageId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        MessageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupMessageId)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Message", t => t.MessageId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.MessageId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageType = c.Int(nullable: false),
                        Msg = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        Mode = c.Int(nullable: false),
                        Attachment_ResourceName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Resource", t => t.Attachment_ResourceName)
                .Index(t => t.Attachment_ResourceName);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        ResourceName = c.String(nullable: false, maxLength: 128),
                        ResourceType = c.Int(),
                        Filename = c.String(nullable: false),
                        UploadedDate = c.DateTime(),
                        UploadedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.ResourceName)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.GroupPermission",
                c => new
                    {
                        GroupPermissionId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupPermissionId)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        PermissionName = c.String(),
                        PermissionDescription = c.String(),
                    })
                .PrimaryKey(t => t.PermissionId);
            
            CreateTable(
                "dbo.GroupResource",
                c => new
                    {
                        GroupResourceId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        ResourceName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.GroupResourceId)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Resource", t => t.ResourceName, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.ResourceName);
            
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
            
            CreateTable(
                "dbo.InactiveUser",
                c => new
                    {
                        InactiveUserId = c.Int(nullable: false, identity: true),
                        InactivatedBy = c.String(),
                        InactivatedDate = c.DateTime(nullable: false),
                        Reason = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InactiveUserId);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        Year = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LevelId);
            
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
            
            CreateTable(
                "dbo.Programme",
                c => new
                    {
                        ProgrammeId = c.Int(nullable: false, identity: true),
                        ProgrammeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProgrammeId);
            
            CreateTable(
                "dbo.Routine",
                c => new
                    {
                        RoutineId = c.Int(nullable: false, identity: true),
                        IssuedDate = c.DateTime(nullable: false),
                        IssuedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoutineId)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.UserMessage",
                c => new
                    {
                        UserMessageId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MessageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserMessageId)
                .ForeignKey("dbo.Message", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MessageId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPermission",
                c => new
                    {
                        UserPermissionId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserPermissionId)
                .ForeignKey("dbo.Permission", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PermissionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserResource",
                c => new
                    {
                        UserResourceId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ResourceName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserResourceId)
                .ForeignKey("dbo.Resource", t => t.ResourceName, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ResourceName)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserResource", "UserId", "dbo.User");
            DropForeignKey("dbo.UserResource", "ResourceName", "dbo.Resource");
            DropForeignKey("dbo.UserPermission", "UserId", "dbo.User");
            DropForeignKey("dbo.UserPermission", "PermissionId", "dbo.Permission");
            DropForeignKey("dbo.UserMessage", "UserId", "dbo.User");
            DropForeignKey("dbo.UserMessage", "MessageId", "dbo.Message");
            DropForeignKey("dbo.Period", "Routine_RoutineId", "dbo.Routine");
            DropForeignKey("dbo.Routine", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Period", "TeacherUserId", "dbo.User");
            DropForeignKey("dbo.MessageReaction", "UserId", "dbo.User");
            DropForeignKey("dbo.MessageReaction", "MessageId", "dbo.Message");
            DropForeignKey("dbo.GroupsUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.GroupsUsers", "GroupId", "dbo.Group");
            DropForeignKey("dbo.GroupResource", "ResourceName", "dbo.Resource");
            DropForeignKey("dbo.GroupResource", "GroupId", "dbo.Group");
            DropForeignKey("dbo.GroupPermission", "PermissionId", "dbo.Permission");
            DropForeignKey("dbo.GroupPermission", "GroupId", "dbo.Group");
            DropForeignKey("dbo.GroupMessage", "MessageId", "dbo.Message");
            DropForeignKey("dbo.Message", "Attachment_ResourceName", "dbo.Resource");
            DropForeignKey("dbo.Resource", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.GroupMessage", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Faculty", "FacultyHeadId", "dbo.User");
            DropForeignKey("dbo.ExamRank", "UserId", "dbo.User");
            DropForeignKey("dbo.ExamMarkSheet", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Subject", "SubjectTeacherId", "dbo.User");
            DropForeignKey("dbo.Subject", "GroupId", "dbo.Group");
            DropForeignKey("dbo.ExamMarkSheet", "UserId", "dbo.User");
            DropForeignKey("dbo.CustomUserProperty", "UserId", "dbo.User");
            DropForeignKey("dbo.CustomGroupProperty", "GroupId", "dbo.Group");
            DropIndex("dbo.UserResource", new[] { "UserId" });
            DropIndex("dbo.UserResource", new[] { "ResourceName" });
            DropIndex("dbo.UserPermission", new[] { "UserId" });
            DropIndex("dbo.UserPermission", new[] { "PermissionId" });
            DropIndex("dbo.UserMessage", new[] { "UserId" });
            DropIndex("dbo.UserMessage", new[] { "MessageId" });
            DropIndex("dbo.Period", new[] { "Routine_RoutineId" });
            DropIndex("dbo.Routine", new[] { "GroupId" });
            DropIndex("dbo.Period", new[] { "TeacherUserId" });
            DropIndex("dbo.MessageReaction", new[] { "UserId" });
            DropIndex("dbo.MessageReaction", new[] { "MessageId" });
            DropIndex("dbo.GroupsUsers", new[] { "UserId" });
            DropIndex("dbo.GroupsUsers", new[] { "GroupId" });
            DropIndex("dbo.GroupResource", new[] { "ResourceName" });
            DropIndex("dbo.GroupResource", new[] { "GroupId" });
            DropIndex("dbo.GroupPermission", new[] { "PermissionId" });
            DropIndex("dbo.GroupPermission", new[] { "GroupId" });
            DropIndex("dbo.GroupMessage", new[] { "MessageId" });
            DropIndex("dbo.Message", new[] { "Attachment_ResourceName" });
            DropIndex("dbo.Resource", new[] { "SubjectId" });
            DropIndex("dbo.GroupMessage", new[] { "GroupId" });
            DropIndex("dbo.Faculty", new[] { "FacultyHeadId" });
            DropIndex("dbo.ExamRank", new[] { "UserId" });
            DropIndex("dbo.ExamMarkSheet", new[] { "SubjectId" });
            DropIndex("dbo.Subject", new[] { "SubjectTeacherId" });
            DropIndex("dbo.Subject", new[] { "GroupId" });
            DropIndex("dbo.ExamMarkSheet", new[] { "UserId" });
            DropIndex("dbo.CustomUserProperty", new[] { "UserId" });
            DropIndex("dbo.CustomGroupProperty", new[] { "GroupId" });
            DropTable("dbo.UserResource");
            DropTable("dbo.UserPermission");
            DropTable("dbo.UserMessage");
            DropTable("dbo.Routine");
            DropTable("dbo.Programme");
            DropTable("dbo.Period");
            DropTable("dbo.MessageReaction");
            DropTable("dbo.Level");
            DropTable("dbo.InactiveUser");
            DropTable("dbo.GroupsUsers");
            DropTable("dbo.GroupResource");
            DropTable("dbo.Permission");
            DropTable("dbo.GroupPermission");
            DropTable("dbo.Resource");
            DropTable("dbo.Message");
            DropTable("dbo.GroupMessage");
            DropTable("dbo.Faculty");
            DropTable("dbo.ExamRank");
            DropTable("dbo.Subject");
            DropTable("dbo.ExamMarkSheet");
            DropTable("dbo.User");
            DropTable("dbo.CustomUserProperty");
            DropTable("dbo.Group");
            DropTable("dbo.CustomGroupProperty");
            DropTable("dbo.Admin");
        }
    }
}
