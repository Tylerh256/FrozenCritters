namespace FrozenCritters.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using FrozenCritters.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FrozenCritters.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FrozenCritters.Models.ApplicationDbContext context)
        {
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
            CreateRoles(context, RoleAction.Admin);
            CreateDefaultAdmin(context, "Russell@hawks.com"); //Default Admin Username
        }

        private void CreateDefaultAdmin(ApplicationDbContext db, string username)
        {
            if (!db.Users.Any(u => u.UserName == username))
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = username,
                    Email = username,
                    EmailConfirmed = true
                };
                userManager.Create(user, "Admin123"); //Default Admin Password
                userManager.AddToRole(user.Id, RoleAction.Admin);
            }
        }

        private void CreateRoles(ApplicationDbContext db, params string[] roles)
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManage = new RoleManager<IdentityRole>(roleStore);

            foreach (var role in roles)
            {
                if (!db.Roles.Any(r => r.Name == role))
                {
                    var identityRole = new IdentityRole
                    {
                        Name = role
                    };
                    roleManage.Create(identityRole);
                }
            }
        }
    }
}
