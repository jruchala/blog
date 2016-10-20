using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using jruchala_blog.Models;
using System.Data.Entity.Migrations;
using System.Linq;
namespace jruchala_blog.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "jruchala@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jruchala@gmail.com",
                    Email = "jruchala@gmail.com",

                    DisplayName = "James Ruchala"
                }, "password");
            }
            if (!context.Users.Any(u => u.Email == "ruchalaj0142@forsythtech.edu"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ruchalaj0142@forsythtech.edu",
                    Email = "ruchalaj0142@forsythtech.edu",

                    DisplayName = "Moderator"
                }, "password");
            }
            if (!context.Users.Any(u => u.Email == "mjaang@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "mjaang@coderfoundry.com",
                    Email = "mjaang@coderfoundry.com",

                    DisplayName = "Moderator"
                }, "Password-1");
            }

            var userId = userManager.FindByEmail("jruchala@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");
            var user_Id = userManager.FindByEmail("ruchalaj0142@forsythtech.edu").Id;
            userManager.AddToRole(user_Id, "Moderator");
            var user_Id2 = userManager.FindByEmail("mjaang@coderfoundry.com").Id;
            userManager.AddToRole(user_Id2, "Moderator");
        }
    }
}