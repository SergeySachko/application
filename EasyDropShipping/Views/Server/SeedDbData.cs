using DAL;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Server
{
    public class SeedDbData
    {
        private readonly ApplicationDbContext context;
        private readonly IHostingEnvironment hostingEnv;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public SeedDbData(IWebHost _host, ApplicationDbContext _context)
        {
            var services = (IServiceScopeFactory)_host.Services.GetService(typeof(IServiceScopeFactory));
            var serviceScope = services.CreateScope();

            hostingEnv = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();
            roleManager = serviceScope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();
            userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

            context = _context;

            CreateRoles();
            CreateUsers();

            context.SaveChanges();
        }

        private void CreateRoles()
        {
            if (!context.ApplicationUsers.Any())
            {
                var rolesToAdd = new List<ApplicationRole>(){
                    new ApplicationRole { Name= "Admin", Description = "Full rights role"},               
                };

                foreach (var role in rolesToAdd)
                {
                    if (!roleManager.RoleExistsAsync(role.Name).Result)
                    {
                        roleManager.CreateAsync(role).Result.ToString();
                    }
                }
            }

        }
        private void CreateUsers()
        {
            if (!context.ApplicationUsers.Any())
            {
                userManager.CreateAsync(new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com", EmailConfirmed = true, CreatedDate = DateTime.Now, IsEnabled = true }, "1").Result.ToString();
                userManager.AddToRoleAsync(userManager.FindByNameAsync("admin@admin.com").GetAwaiter().GetResult(), "Admin").Result.ToString();               
            }
        }
    }
}
