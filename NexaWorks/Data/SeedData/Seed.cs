//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using NexaWorks.Models.Entities;
//using System;
//using System.Linq;
//using OperatingSystem = NexaWorks.Models.Entities.OperatingSystem;
//using Version = NexaWorks.Models.Entities.Version;


//namespace NexaWorks.Data.SeedData
//{
//    public class Seed
//    {
//        public static async Task Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new ApplicationDbContext(
//               serviceProvider.GetRequiredService<
//                   DbContextOptions<ApplicationDbContext>>()))
//            {
//                if (!context.OperatingSystems.Any())
//                {
//                    context.OperatingSystems.AddRange(
//                        new OperatingSystem { Id = 1, Name = "Linux" },
//                        new OperatingSystem { Id = 2, Name = "macOS" },
//                        new OperatingSystem { Id = 3, Name = "Windows" },
//                        new OperatingSystem { Id = 4, Name = "Android" },
//                        new OperatingSystem { Id = 5, Name = "iOS" },
//                        new OperatingSystem { Id = 6, Name = "Windows Mobile" }
//                    );
//                }

//                if (!context.Products.Any())
//                {
//                    context.Products.AddRange(
//                        new Product { Id = 1, Name = "Trader en Herbe" },
//                        new Product { Id = 2, Name = " Maître des Investissements" },
//                        new Product { Id = 3, Name = " Planificateur d’Entraînement" },
//                        new Product { Id = 4, Name = " Planificateur d’Anxiété Sociale" }
//                    );
//                }

//                if (!context.Versions.Any())
//                {
//                    context.Versions.AddRange(
//                         new Version { Id = 1, ProductId = 1, Name = 1.0f },
//                         new Version { Id = 2, ProductId = 1, Name = 1.1f },
//                         new Version { Id = 3, ProductId = 1, Name = 1.2f },
//                         new Version { Id = 4, ProductId = 1, Name = 1.3f },
//                         new Version { Id = 5, ProductId = 2, Name = 1.0f },
//                         new Version { Id = 6, ProductId = 2, Name = 2.0f },
//                         new Version { Id = 7, ProductId = 2, Name = 2.1f },
//                         new Version { Id = 8, ProductId = 3, Name = 1.0f },
//                         new Version { Id = 9, ProductId = 3, Name = 1.1f },
//                         new Version { Id = 10, ProductId = 3, Name = 2.0f },
//                         new Version { Id = 11, ProductId = 4, Name = 1.0f },
//                         new Version { Id = 12, ProductId = 4, Name = 1.1f }
//                    );

//                    if (!context.ProductVersionOperatingSystems.Any())
//                    {
//                        context.ProductVersionOperatingSystems.AddRange(
//                            //trader en herbe version1.0
//                            new ProductVersionOperatingSystem { Id = 1, ProductId = 1, VersionId = 1, OperatingSystemId = 1 },
//                            new ProductVersionOperatingSystem { Id = 2, ProductId = 1, VersionId = 1, OperatingSystemId = 3 },
//                            //trader en herbe version1.1
//                            new ProductVersionOperatingSystem { Id = 3, ProductId = 1, VersionId = 2, OperatingSystemId = 1 },
//                            new ProductVersionOperatingSystem { Id = 4, ProductId = 1, VersionId = 2, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 5, ProductId = 1, VersionId = 2, OperatingSystemId = 3 },
//                            //trader en herbe version1.2
//                            new ProductVersionOperatingSystem { Id = 6, ProductId = 1, VersionId = 3, OperatingSystemId = 1 },
//                            new ProductVersionOperatingSystem { Id = 7, ProductId = 1, VersionId = 3, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 8, ProductId = 1, VersionId = 3, OperatingSystemId = 3 },
//                            new ProductVersionOperatingSystem { Id = 9, ProductId = 1, VersionId = 3, OperatingSystemId = 4 },
//                            new ProductVersionOperatingSystem { Id = 10, ProductId = 1, VersionId = 3, OperatingSystemId = 5 },
//                            new ProductVersionOperatingSystem { Id = 11, ProductId = 1, VersionId = 3, OperatingSystemId = 6 },
//                            //trader en herbe version1.3
//                            new ProductVersionOperatingSystem { Id = 12, ProductId = 1, VersionId = 4, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 13, ProductId = 1, VersionId = 4, OperatingSystemId = 3 },
//                            new ProductVersionOperatingSystem { Id = 14, ProductId = 1, VersionId = 4, OperatingSystemId = 4 },
//                            new ProductVersionOperatingSystem { Id = 15, ProductId = 1, VersionId = 4, OperatingSystemId = 5 },
//                            // maître des investissements version1.0
//                            new ProductVersionOperatingSystem { Id = 16, ProductId = 2, VersionId = 5, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 17, ProductId = 2, VersionId = 5, OperatingSystemId = 5 },
//                            // maître des investissements version2.0
//                            new ProductVersionOperatingSystem { Id = 18, ProductId = 2, VersionId = 6, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 19, ProductId = 2, VersionId = 6, OperatingSystemId = 4 },
//                            new ProductVersionOperatingSystem { Id = 20, ProductId = 2, VersionId = 6, OperatingSystemId = 5 },
//                            // maître des investissements version2.1
//                            new ProductVersionOperatingSystem { Id = 21, ProductId = 2, VersionId = 7, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 22, ProductId = 2, VersionId = 7, OperatingSystemId = 3 },
//                            new ProductVersionOperatingSystem { Id = 23, ProductId = 2, VersionId = 7, OperatingSystemId = 4 },
//                            new ProductVersionOperatingSystem { Id = 24, ProductId = 2, VersionId = 7, OperatingSystemId = 5 },
//                            // planificateur d’entraînement version1.0
//                            new ProductVersionOperatingSystem { Id = 25, ProductId = 3, VersionId = 8, OperatingSystemId = 1 },
//                            new ProductVersionOperatingSystem { Id = 26, ProductId = 3, VersionId = 8, OperatingSystemId = 2 },
//                            // planificateur d’entraînement version1.1
//                            new ProductVersionOperatingSystem { Id = 27, ProductId = 3, VersionId = 9, OperatingSystemId = 1 },
//                            new ProductVersionOperatingSystem { Id = 28, ProductId = 3, VersionId = 9, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 29, ProductId = 3, VersionId = 9, OperatingSystemId = 3 },
//                            new ProductVersionOperatingSystem { Id = 30, ProductId = 3, VersionId = 9, OperatingSystemId = 4 },
//                            new ProductVersionOperatingSystem { Id = 31, ProductId = 3, VersionId = 9, OperatingSystemId = 5 },
//                            new ProductVersionOperatingSystem { Id = 32, ProductId = 3, VersionId = 9, OperatingSystemId = 6 },
//                            //planificateur d’entraînement version2.0
//                            new ProductVersionOperatingSystem { Id = 33, ProductId = 3, VersionId = 10, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 34, ProductId = 3, VersionId = 10, OperatingSystemId = 3 },
//                            new ProductVersionOperatingSystem { Id = 35, ProductId = 3, VersionId = 10, OperatingSystemId = 4 },
//                            new ProductVersionOperatingSystem { Id = 36, ProductId = 3, VersionId = 10, OperatingSystemId = 5 },
//                            // planificateur d’anxiété sociale version1.0
//                            new ProductVersionOperatingSystem { Id = 37, ProductId = 4, VersionId = 11, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 38, ProductId = 4, VersionId = 11, OperatingSystemId = 3 },
//                            new ProductVersionOperatingSystem { Id = 39, ProductId = 4, VersionId = 11, OperatingSystemId = 4 },
//                            new ProductVersionOperatingSystem { Id = 40, ProductId = 4, VersionId = 11, OperatingSystemId = 5 },
//                            // planificateur d’anxiété sociale version1.1
//                            new ProductVersionOperatingSystem { Id = 41, ProductId = 4, VersionId = 12, OperatingSystemId = 2 },
//                            new ProductVersionOperatingSystem { Id = 42, ProductId = 4, VersionId = 12, OperatingSystemId = 3 },
//                            new ProductVersionOperatingSystem { Id = 43, ProductId = 4, VersionId = 12, OperatingSystemId = 4 },
//                            new ProductVersionOperatingSystem { Id = 44, ProductId = 4, VersionId = 12, OperatingSystemId = 5 }
//                            );

//                    }


//                }


//            }






//        }
//    }
//}


