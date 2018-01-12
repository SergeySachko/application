using Application.Server.Extensions;
using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace Application.Server
{
    public class ProcessDbCommands
    {
        public static void Process(string[] args, IWebHost host)
        {


            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));
            var enviroment = services.CreateScope().ServiceProvider.GetService<IHostingEnvironment>();

            using (var scope = services.CreateScope())
            {
                var db = GetApplicationDbContext(scope);
                if (args == null || args.Count() == 0 )
                {
                    if (enviroment.EnvironmentName.ToUpper() == "PRODUCTION")
                    {
                        if (!DbContextExtensions.AllMigrationsApplied(db))
                        {
                            db.Database.Migrate();                            
                        }
                    }
                    else
                    {
                        if (!DbContextExtensions.AllMigrationsApplied(db))
                        {
                            db.Database.Migrate();
                            db.Seed(host);
                        }
                        else
                        {
                            db.Seed(host);
                        }
                    }
                    return;
                }               

                if (args.Contains("migratedb"))
                {
                    Console.WriteLine("Migrating database");
                    db.Database.Migrate();
                }

                if (args.Contains("seeddb"))
                {
                    Console.WriteLine("Seeding database");
                    db.Seed(host);
                }
                if (enviroment.EnvironmentName.ToUpper() == "PRODUCTION")
                {
                    if (!DbContextExtensions.AllMigrationsApplied(db))
                    {
                        db.Database.Migrate();
                        //TODO: Maybe it should remove from this , becouse it can overwrite data in database
                        db.Seed(host);
                    }
                }

            }
        }

        private static ApplicationDbContext GetApplicationDbContext(IServiceScope services)
        {
            var db = services.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db;
        }
    }
}
