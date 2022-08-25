using System;
using System.Linq;
using DotNet_Microservices.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_Microservices.Data
{
    public static class PrepDb
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SendData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SendData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data");
                context.Platforms.AddRange(
                    new Platform(){Name = "Dot Net",Publisher = "Microsoft", Cost ="Free"},
                    new Platform(){Name = "SQL Server Express",Publisher = "Microsoft", Cost ="Free"},
                    new Platform(){Name = "Kubernates",Publisher = "Cloud Native Computing Foundation", Cost ="Free"}
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}