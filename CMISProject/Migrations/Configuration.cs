namespace CMISProject.Migrations
{
    using CMISProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CMISProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CMISProject.Models.ApplicationDbContext context)
        {
            this.AddUserAndRoles();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        bool AddUserAndRoles()
        {
            bool success = false;

            var im = new IdentityManager();
            success = im.CreateRole("SuperAdmin");
            if (!success) return success;

            var user = new ApplicationUser()
            {
                UserName = "gopal",
            };

            success = im.CreateUser(user, "ramjane");
            if (!success) return success;

            success = im.AddUserToRole(user.Id, "SuperAdmin");
            if (!success) return success;

            return success;

        }
    }
}
