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
                        Name = c.String(nullable: false, maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 30),
                        DateOfEstablishment = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber1 = c.Long(nullable: false),
                        PhoneNumber2 = c.Long(nullable: false),
                        PhoneNumber3 = c.Long(nullable: false),
                        POBoxNumber = c.String(nullable: false),
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
                        Property = c.String(nullable: false),
                        Value = c.String(nullable: false, maxLength: 50),
                        Group_GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomGroupPropertyId)
                .ForeignKey("dbo.Group", t => t.Group_GroupId, cascadeDelete: true)
                .Index(t => t.Group_GroupId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Psswd = c.String(nullable: false, maxLength: 30),
                        GroupName = c.String(nullable: false, maxLength: 30),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Subgroup = c.String(maxLength: 30),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.CustomUserProperty",
                c => new
                    {
                        CustomUserPropertyId = c.Int(nullable: false, identity: true),
                        Property = c.String(nullable: false),
                        Value = c.String(nullable: false, maxLength: 50),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomUserPropertyId)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Nationality = c.String(nullable: false),
                        ImageFile = c.String(),
                        BloodGroup = c.String(),
                        CitizenShipNumber = c.String(),
                        Semester = c.Int(),
                        GuardianName1 = c.String(),
                        GuardianAddress1 = c.String(),
                        GuardianName2 = c.String(),
                        GuardianAddress2 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        CreatedBy_UserId = c.Int(nullable: false),
                        Group_GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Group", t => t.Group_GroupId)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.Group_GroupId);
            
            CreateTable(
                "dbo.ExamMarkSheet",
                c => new
                    {
                        ExamMarkSheetId = c.Int(nullable: false, identity: true),
                        Marks = c.Int(nullable: false),
                        ExamType = c.String(nullable: false),
                        FullMarks = c.Int(nullable: false),
                        PassMarks = c.Int(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                        SubjectRank = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                        SGPA = c.Int(nullable: false),
                        Student_UserId = c.Int(nullable: false),
                        Subject_SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamMarkSheetId)
                .ForeignKey("dbo.User", t => t.Student_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.Subject_SubjectId, cascadeDelete: true)
                .Index(t => t.Student_UserId)
                .Index(t => t.Subject_SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubName = c.String(nullable: false),
                        CreditHrs = c.Int(nullable: false),
                        PriBook = c.String(nullable: false),
                        RefBook1 = c.String(),
                        RefBook2 = c.String(),
                        Group_GroupId = c.Int(nullable: false),
                        SubTeacher_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Group", t => t.Group_GroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.SubTeacher_UserId, cascadeDelete: false)
                .Index(t => t.Group_GroupId)
                .Index(t => t.SubTeacher_UserId);
            
            CreateTable(
                "dbo.ExamRank",
                c => new
                    {
                        ExamRankId = c.Int(nullable: false, identity: true),
                        Percentage = c.Int(nullable: false),
                        TotalMarks = c.Int(nullable: false),
                        Rank = c.Int(nullable: false),
                        SGPA = c.Int(nullable: false),
                        Student_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamRankId)
                .ForeignKey("dbo.User", t => t.Student_UserId, cascadeDelete: true)
                .Index(t => t.Student_UserId);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false),
                        FacultyHead_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId)
                .ForeignKey("dbo.User", t => t.FacultyHead_UserId, cascadeDelete: true)
                .Index(t => t.FacultyHead_UserId);
            
            CreateTable(
                "dbo.GroupMessage",
                c => new
                    {
                        GroupMessageId = c.Int(nullable: false, identity: true),
                        Group_GroupId = c.Int(),
                        Messsage_MessageId = c.Int(),
                    })
                .PrimaryKey(t => t.GroupMessageId)
                .ForeignKey("dbo.Group", t => t.Group_GroupId)
                .ForeignKey("dbo.Message", t => t.Messsage_MessageId)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Messsage_MessageId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageType = c.Int(nullable: false),
                        Msg = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        React = c.Int(nullable: false),
                        Mode = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.User", t => t.CreatedBy_UserId, cascadeDelete: true)
                .Index(t => t.CreatedBy_UserId);
            
            CreateTable(
                "dbo.GroupPermission",
                c => new
                    {
                        GroupPermissionId = c.Int(nullable: false, identity: true),
                        Group_GroupId = c.Int(),
                        Permission_PermissionId = c.Int(),
                    })
                .PrimaryKey(t => t.GroupPermissionId)
                .ForeignKey("dbo.Group", t => t.Group_GroupId)
                .ForeignKey("dbo.Permission", t => t.Permission_PermissionId)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Permission_PermissionId);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        Perm = c.String(),
                    })
                .PrimaryKey(t => t.PermissionId);
            
            CreateTable(
                "dbo.GroupResource",
                c => new
                    {
                        GroupResourceId = c.Int(nullable: false, identity: true),
                        GrpResId = c.Int(nullable: false),
                        Group_GroupId = c.Int(nullable: false),
                        Resource_ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupResourceId)
                .ForeignKey("dbo.Group", t => t.Group_GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Resource", t => t.Resource_ResourceId, cascadeDelete: true)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Resource_ResourceId);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        Rtype = c.Int(nullable: false),
                        ResName = c.String(nullable: false),
                        Filename = c.String(nullable: false),
                        UploadedDate = c.DateTime(nullable: false),
                        Subject_SubjectId = c.Int(nullable: false),
                        UploadedBy_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceId)
                .ForeignKey("dbo.Subject", t => t.Subject_SubjectId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UploadedBy_UserId, cascadeDelete: true)
                .Index(t => t.Subject_SubjectId)
                .Index(t => t.UploadedBy_UserId);
            
            CreateTable(
                "dbo.InactiveUser",
                c => new
                    {
                        InactiveUserId = c.Int(nullable: false, identity: true),
                        InactiveDate = c.String(nullable: false),
                        Reason = c.String(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InactiveUserId)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        Year = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LevelId);
            
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
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Day = c.Int(nullable: false),
                        BreakRemark = c.Int(nullable: false),
                        Group_GroupId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoutineId)
                .ForeignKey("dbo.Group", t => t.Group_GroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Group_GroupId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserMessage",
                c => new
                    {
                        UserMessageId = c.Int(nullable: false, identity: true),
                        Messsage_MessageId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserMessageId)
                .ForeignKey("dbo.Message", t => t.Messsage_MessageId)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .Index(t => t.Messsage_MessageId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserPermission",
                c => new
                    {
                        UserPermissionId = c.Int(nullable: false, identity: true),
                        Permission_PermissionId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserPermissionId)
                .ForeignKey("dbo.Permission", t => t.Permission_PermissionId)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .Index(t => t.Permission_PermissionId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserResource",
                c => new
                    {
                        UserResourceId = c.Int(nullable: false, identity: true),
                        Resource_ResourceId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserResourceId)
                .ForeignKey("dbo.Resource", t => t.Resource_ResourceId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: false)
                .Index(t => t.Resource_ResourceId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserResource", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserResource", "Resource_ResourceId", "dbo.Resource");
            DropForeignKey("dbo.UserPermission", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserPermission", "Permission_PermissionId", "dbo.Permission");
            DropForeignKey("dbo.UserMessage", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserMessage", "Messsage_MessageId", "dbo.Message");
            DropForeignKey("dbo.Routine", "User_UserId", "dbo.User");
            DropForeignKey("dbo.Routine", "Group_GroupId", "dbo.Group");
            DropForeignKey("dbo.InactiveUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.GroupResource", "Resource_ResourceId", "dbo.Resource");
            DropForeignKey("dbo.Resource", "UploadedBy_UserId", "dbo.User");
            DropForeignKey("dbo.Resource", "Subject_SubjectId", "dbo.Subject");
            DropForeignKey("dbo.GroupResource", "Group_GroupId", "dbo.Group");
            DropForeignKey("dbo.GroupPermission", "Permission_PermissionId", "dbo.Permission");
            DropForeignKey("dbo.GroupPermission", "Group_GroupId", "dbo.Group");
            DropForeignKey("dbo.GroupMessage", "Messsage_MessageId", "dbo.Message");
            DropForeignKey("dbo.Message", "CreatedBy_UserId", "dbo.User");
            DropForeignKey("dbo.GroupMessage", "Group_GroupId", "dbo.Group");
            DropForeignKey("dbo.Faculty", "FacultyHead_UserId", "dbo.User");
            DropForeignKey("dbo.ExamRank", "Student_UserId", "dbo.User");
            DropForeignKey("dbo.ExamMarkSheet", "Subject_SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Subject", "SubTeacher_UserId", "dbo.User");
            DropForeignKey("dbo.Subject", "Group_GroupId", "dbo.Group");
            DropForeignKey("dbo.ExamMarkSheet", "Student_UserId", "dbo.User");
            DropForeignKey("dbo.CustomUserProperty", "User_UserId", "dbo.User");
            DropForeignKey("dbo.User", "Group_GroupId", "dbo.Group");
            DropForeignKey("dbo.User", "CreatedBy_UserId", "dbo.User");
            DropForeignKey("dbo.CustomGroupProperty", "Group_GroupId", "dbo.Group");
            DropIndex("dbo.UserResource", new[] { "User_UserId" });
            DropIndex("dbo.UserResource", new[] { "Resource_ResourceId" });
            DropIndex("dbo.UserPermission", new[] { "User_UserId" });
            DropIndex("dbo.UserPermission", new[] { "Permission_PermissionId" });
            DropIndex("dbo.UserMessage", new[] { "User_UserId" });
            DropIndex("dbo.UserMessage", new[] { "Messsage_MessageId" });
            DropIndex("dbo.Routine", new[] { "User_UserId" });
            DropIndex("dbo.Routine", new[] { "Group_GroupId" });
            DropIndex("dbo.InactiveUser", new[] { "User_UserId" });
            DropIndex("dbo.GroupResource", new[] { "Resource_ResourceId" });
            DropIndex("dbo.Resource", new[] { "UploadedBy_UserId" });
            DropIndex("dbo.Resource", new[] { "Subject_SubjectId" });
            DropIndex("dbo.GroupResource", new[] { "Group_GroupId" });
            DropIndex("dbo.GroupPermission", new[] { "Permission_PermissionId" });
            DropIndex("dbo.GroupPermission", new[] { "Group_GroupId" });
            DropIndex("dbo.GroupMessage", new[] { "Messsage_MessageId" });
            DropIndex("dbo.Message", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.GroupMessage", new[] { "Group_GroupId" });
            DropIndex("dbo.Faculty", new[] { "FacultyHead_UserId" });
            DropIndex("dbo.ExamRank", new[] { "Student_UserId" });
            DropIndex("dbo.ExamMarkSheet", new[] { "Subject_SubjectId" });
            DropIndex("dbo.Subject", new[] { "SubTeacher_UserId" });
            DropIndex("dbo.Subject", new[] { "Group_GroupId" });
            DropIndex("dbo.ExamMarkSheet", new[] { "Student_UserId" });
            DropIndex("dbo.CustomUserProperty", new[] { "User_UserId" });
            DropIndex("dbo.User", new[] { "Group_GroupId" });
            DropIndex("dbo.User", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.CustomGroupProperty", new[] { "Group_GroupId" });
            DropTable("dbo.UserResource");
            DropTable("dbo.UserPermission");
            DropTable("dbo.UserMessage");
            DropTable("dbo.Routine");
            DropTable("dbo.Programme");
            DropTable("dbo.Level");
            DropTable("dbo.InactiveUser");
            DropTable("dbo.Resource");
            DropTable("dbo.GroupResource");
            DropTable("dbo.Permission");
            DropTable("dbo.GroupPermission");
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
