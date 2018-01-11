using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Server;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SplitArgument(args, out string[] dbArgs, out string[] commonArgs);

            var host = BuildWebHost(commonArgs);

            ProcessDbCommands.Process(dbArgs, host);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                  .AddCommandLine(args)
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("hosting.json", optional: true)
                  .Build()
                )
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

        private static void SplitArgument(string[] args, out string[] dbArgs, out string[] commonArgs)
        {
            dbArgs = args.Where(x => x.Contains("seeddb") || x.Contains("migratedb")).ToArray();
            commonArgs = args.Except(dbArgs).ToArray();
        }
    }
}
