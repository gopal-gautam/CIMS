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

            //modelBuilder.Entity<Group>()
            //    .HasRequired(m => m.CreatedBy);
        }

        public override int SaveChanges()
        {

            foreach (var admin in ChangeTracker.Entries<Admin>())//.Where(s => s.State == EntityState.Modified))
            {
                if(admin.State == EntityState.Modified)
                {
                    admin.Entity.ModifiedDate = DateTime.Now;
                    admin.Entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
                }
                else if (admin.State == EntityState.Added)
                {
                    admin.Entity.CreatedDate = DateTime.Now;
                    admin.Entity.CreatedBy = HttpContext.Current.User.Identity.Name;
                }
            }

            foreach (var group in ChangeTracker.Entries<Group>().Where(s => s.State == EntityState.Modified))
            {
                if (group.State == EntityState.Modified)
                {
                    group.Entity.ModifiedDate = DateTime.Now;
                    group.Entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
                }
                else if (group.State == EntityState.Added)
                {
                    group.Entity.CreatedDate = DateTime.Now;
                    group.Entity.CreatedBy = HttpContext.Current.User.Identity.Name;
                }
                
            }

            foreach (var message in ChangeTracker.Entries<Message>().Where(s => s.State == EntityState.Modified))
            {
                if (message.State == EntityState.Modified)
                {
                    message.Entity.ModifiedDate = DateTime.Now;
                    message.Entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
                }
                else if (message.State == EntityState.Added)
                {
                    message.Entity.CreatedDate = DateTime.Now;
                    message.Entity.CreatedBy = HttpContext.Current.User.Identity.Name;
                }
                
            }

            foreach (var resource in ChangeTracker.Entries<Resource>().Where(s => s.State == EntityState.Modified))
            {
                if (resource.State == EntityState.Modified)
                {
                    resource.Entity.ModifiedDate = DateTime.Now;
                    resource.Entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
                }
                else if (resource.State == EntityState.Added)
                {
                    resource.Entity.UploadedDate = DateTime.Now;
                    resource.Entity.UploadedBy = HttpContext.Current.User.Identity.Name;
                } 
            }

            foreach (var routine in ChangeTracker.Entries<Routine>().Where(s => s.State == EntityState.Modified))
            {
                if (routine.State == EntityState.Modified)
                {
                    routine.Entity.ModifiedDate = DateTime.Now;
                    routine.Entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
                }
                else if (routine.State == EntityState.Added)
                {
                    routine.Entity.IssuedDate = DateTime.Now;
                    routine.Entity.IssuedBy = HttpContext.Current.User.Identity.Name;
                }
            }

            foreach (var user in ChangeTracker.Entries<User>().Where(s => s.State == EntityState.Modified))
            {
                if (user.State == EntityState.Modified)
                {
                    user.Entity.ModifiedDate = DateTime.Now;
                    user.Entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
                }
                else if (user.State == EntityState.Added)
                {
                    user.Entity.CreatedDate = DateTime.Now;
                    user.Entity.CreatedBy = HttpContext.Current.User.Identity.Name;
                }
            }

            foreach (var inactiveUser in ChangeTracker.Entries<InactiveUser>().Where(s => s.State == EntityState.Added))
            {
                inactiveUser.Entity.InactivatedDate = DateTime.Now;
                inactiveUser.Entity.InactivatedBy = HttpContext.Current.User.Identity.Name;
            }
            return base.SaveChanges();
        }

    }
}