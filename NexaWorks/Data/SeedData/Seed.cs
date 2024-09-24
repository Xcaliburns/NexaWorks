using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NexaWorks.Models.Entities;
using System;
using System.Linq;


namespace NexaWorks.Data.SeedData
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Vérifier si la base de données contient déjà des produits
                if (context.Products.Any())
                {
                    return;   // La base de données a déjà été peuplée
                }

                context.Products.AddRange(
                    new Product
                    {
                       ProductName = "Product1"
                       
                    }
                   
                );

                context.SaveChanges();
            }
        }
    }
}

