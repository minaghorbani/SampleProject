using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Domain.Identity;
using WebPresentation.Common;
using Serilog;
namespace WebPresentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var path = Environment.CurrentDirectory;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .MinimumLevel.Information()
                .WriteTo.SQLite(path+@"\logs.db")

                .CreateLogger();

            var host = CreateHostBuilder(args).Build();
            if (args.Length == 1 && args[0] == "init")
            {
                using (var scop = host.Services.CreateScope())
                {
                    var serviceProvider = scop.ServiceProvider;

                    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var seedIdentity = new SeedIdentityData(userManager,roleManager);
                    await seedIdentity.Init();

                }
            }
            else
            {
                host.Run();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
