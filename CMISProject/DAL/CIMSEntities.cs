using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CMISProject.DAL
{
    public class CIMSEntities : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<InactiveUser> InactiveUsers { get; set; }
        public DbSet<CustomUserProperty> CustomUserProperties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<CustomGroupProperty> CustomGroupProperties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<GroupResource> GroupResources { get; set; }
        public DbSet<UserResource> UserResources { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ExamMarkSheet> ExamMarkSheets { get; set; }
        public DbSet<ExamRank> ExamRanks { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Programme> Programmes { get; set; }

        //Removing the default tablename pluralization
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}