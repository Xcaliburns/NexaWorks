using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NexaWorks.Models.Entities;
using System;
using System.Linq;
using OperatingSystem = NexaWorks.Models.Entities.OperatingSystem;
using Version = NexaWorks.Models.Entities.Version;
using Product = NexaWorks.Models.Entities.Product;
using Ticket = NexaWorks.Models.Entities.Ticket;
using TicketResolution = NexaWorks.Models.Entities.TicketResolution;
using ProductVersionOperatingSystem = NexaWorks.Models.Entities.ProductVersionOperatingSystem;


namespace NexaWorks.Data.SeedData
{
    public class Seed
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //TODO: verifier avec Laala
                context.Database.EnsureCreated();

                try
                {//TODO : essayer de la meme maniere pour le reste cela fonctionne ici
                    if (!context.OperatingSystems.Any())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            AddOperatingSystems(context,
                                "Linux",
                                "macOS",
                                "Windows",
                                "Android",
                                "iOS",
                                "Windows Mobile"
                            );
                            await context.SaveChangesAsync();
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
                    throw; // Re-throw the exception to ensure the application is aware of the failure
                }

                try
                {
                    if (!context.Products.Any())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON");
                            AddProducts(context,
                                (1, "Trader en Herbe"),
                                (2, "Maître des Investissements"),
                                (3, "Planificateur d’Entraînement"),
                                (4, "Planificateur d’Anxiété Sociale")
                            );
                            await context.SaveChangesAsync();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products OFF");
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the Products table: {ex.Message}");
                    throw;
                }


                try
                {
                    if (!context.Versions.Any())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Versions ON");
                            AddVersions(context,
                                (1, 1, 1.0f),
                                (2, 1, 1.1f),
                                (3, 1, 1.2f),
                                (4, 1, 1.3f),
                                (5, 2, 1.0f),
                                (6, 2, 2.0f),
                                (7, 2, 2.1f),
                                (8, 3, 1.0f),
                                (9, 3, 1.1f),
                                (10, 3, 2.0f),
                                (11, 4, 1.0f),
                                (12, 4, 1.1f)
                            );
                            await context.SaveChangesAsync();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Versions OFF");
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the Versions table: {ex.Message}");
                    throw;
                }

                try
                {
                    if (!context.ProductVersionOperatingSystems.Any())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductVersionOperatingSystems ON");

                            // Trader en Herbe
                            AddProductVersionOperatingSystems(context, 1, 1, new[] { 7, 9 }); // version 1.0
                            AddProductVersionOperatingSystems(context, 1, 2, new[] { 7, 8, 9 }); // version 1.1
                            AddProductVersionOperatingSystems(context, 1, 3, new[] { 7, 8, 9, 10, 11, 12 }); // version 1.2
                            AddProductVersionOperatingSystems(context, 1, 4, new[] { 8, 9, 10, 11 }); // version 1.3

                            // Maître des Investissements
                            AddProductVersionOperatingSystems(context, 2, 5, new[] { 8, 11 }); // version 1.0
                            AddProductVersionOperatingSystems(context, 2, 6, new[] { 8, 10, 11 }); // version 2.0
                            AddProductVersionOperatingSystems(context, 2, 7, new[] { 8, 9, 10, 11 }); // version 2.1

                            // Planificateur d’Entraînement
                            AddProductVersionOperatingSystems(context, 3, 8, new[] { 7, 8 }); // version 1.0
                            AddProductVersionOperatingSystems(context, 3, 9, new[] { 7, 8, 9, 10, 11, 12 }); // version 1.1
                            AddProductVersionOperatingSystems(context, 3, 10, new[] { 8, 9, 10, 11 }); // version 2.0

                            // Planificateur d'Anxiété Sociale
                            AddProductVersionOperatingSystems(context, 4, 11, new[] { 8, 9, 10, 11 }); // version 1.0
                            AddProductVersionOperatingSystems(context, 4, 12, new[] {8, 9, 10, 11 }); // version 1.1

                            await context.SaveChangesAsync();
                            //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductVersionOperatingSystems OFF");
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the ProductVersionOperatingSystems table: {ex.Message}");
                    throw;
                }

                try
                {
                    if (!context.Tickets.Any())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets ON");
                            AddTickets(context,
                                (1, DateTime.Now, true, "Problème de connexion", 1),
                                (2, DateTime.Now, false, "Erreur de calcul", 2),
                                (3, DateTime.Now, true, "Problème d'affichage", 3)
                            );
                            await context.SaveChangesAsync();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets OFF");
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the Tickets table: {ex.Message}");
                    throw;
                }

                try
                {
                    if (!context.TicketResolutions.Any())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT TicketResolutions ON");
                            AddTicketResolutions(context,
                                (1, "Résolu en redémarrant l'application", DateTime.Now, 1),
                                (2, "Mise à jour de l'application", DateTime.Now, 2)
                            );
                            await context.SaveChangesAsync();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT TicketResolutions OFF");
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the TicketResolutions table: {ex.Message}");
                    throw;
                }
            }
        }

        // Utilitaire pour ajouter un OperatingSystem
        private static void AddOperatingSystem(ApplicationDbContext context, int osId, string osName)
        {
            context.OperatingSystems.Add(new OperatingSystem
            {
                Id = osId,
                Name = osName
            });
        }

        // Utilitaire pour ajouter un ensemble de OperatingSystem
        private static void AddOperatingSystems(ApplicationDbContext context, params string[] operatingSystems)
        {
            foreach (var osName in operatingSystems)
            {
                context.OperatingSystems.Add(new OperatingSystem
                {
                    Name = osName
                });
            }
        }

        // Utilitaire pour ajouter un Product
        private static void AddProduct(ApplicationDbContext context, int productId, string productName)
        {
            context.Products.Add(new Product
            {
                Id = productId,
                Name = productName
            });
        }

        // Utilitaire pour ajouter un ensemble de Product
        private static void AddProducts(ApplicationDbContext context, params (int Id, string Name)[] products)
        {
            foreach (var product in products)
            {
                AddProduct(context, product.Id, product.Name);
            }
        }

        // Utilitaire pour ajouter une Version
        private static void AddVersion(ApplicationDbContext context, int versionId, int productId, float versionName)
        {
            context.Versions.Add(new Version
            {
                Id = versionId,
                ProductId = productId,
                Name = versionName
            });
        }

        // Utilitaire pour ajouter un ensemble de Version
        //TODO : verifier avec Laala:ici j'ajoute explicitement l'Id pour chaque version
        //cela m'oblige à ajouter les lignes context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets ON");
        //et context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets OFF");
        
        private static void AddVersions(ApplicationDbContext context, params (int Id, int ProductId, float Name)[] versions)
        {
            foreach (var version in versions)
            {
                AddVersion(context, version.Id, version.ProductId, version.Name);
            }
        }

        // Utilitaire pour ajouter un ProductVersionOperatingSystem
        private static void AddProductVersionOperatingSystem(ApplicationDbContext context, int productId, int versionId, int osId)
        {
            // Récupération des entités liées via leurs IDs
            var product = context.Products.Find(productId);
            var version = context.Versions.Find(versionId);
            var operatingSystem = context.OperatingSystems.Find(osId);

            // Validation des références externes
            if (product == null || version == null || operatingSystem == null)
            {
                throw new InvalidOperationException("Invalid foreign key reference.");
            }

            // Ajout de la nouvelle relation dans la table intermédiaire sans spécifier d'ID
            context.ProductVersionOperatingSystems.Add(new ProductVersionOperatingSystem
            {
                ProductId = productId,
                VersionId = versionId,
                OperatingSystemId = osId,
                Product = product,
                Version = version,
                OperatingSystem = operatingSystem
            });

            // Sauvegarde des modifications
            context.SaveChanges();
        }




        // Utilitaire pour ajouter un ensemble de ProductVersionOperatingSystem
        private static void AddProductVersionOperatingSystems(ApplicationDbContext context, int productId, int versionId, IEnumerable<int> operatingSystemIds)
        {
            foreach (var osId in operatingSystemIds)
            {
                AddProductVersionOperatingSystem(context, productId, versionId, osId);
            }
        }

        // Utilitaire pour ajouter un Ticket
        //TODO : je penseque je devrais retirer l'id du ticket pour qu'il soit auto incrementé
        private static void AddTicket(ApplicationDbContext context, int ticketId, DateTime creationDate, bool status, string problemDescription, int productVersionOperatingSystemId)
        {
            context.Tickets.Add(new Ticket
            {
                Id = ticketId,
                CreationDate = creationDate,
                Status = status,
                ProblemDescription = problemDescription,
                ProductVersionOperatingSystemId = productVersionOperatingSystemId
            });
        }

        // Utilitaire pour ajouter un ensemble de Tickets
        private static void AddTickets(ApplicationDbContext context, params (int Id, DateTime CreationDate, bool Status, string ProblemDescription, int ProductVersionOperatingSystemId)[] tickets)
        {
            foreach (var ticket in tickets)
            {
                AddTicket(context, ticket.Id, ticket.CreationDate, ticket.Status, ticket.ProblemDescription, ticket.ProductVersionOperatingSystemId);
            }
        }

        // Utilitaire pour ajouter une TicketResolution
        private static void AddTicketResolution(ApplicationDbContext context, int ticketResolutionId, string resolutionDescription, DateTime resolutionDate, int ticketId)
        {
            context.TicketResolutions.Add(new TicketResolution
            {
                Id = ticketResolutionId,
                ResolutionDescription = resolutionDescription,
                ResolutionDate = resolutionDate,
                TicketId = ticketId
            });
        }

        // Utilitaire pour ajouter un ensemble de TicketResolutions
        private static void AddTicketResolutions(ApplicationDbContext context, params (int Id, string ResolutionDescription, DateTime ResolutionDate, int TicketId)[] ticketResolutions)
        {
            foreach (var ticketResolution in ticketResolutions)
            {
                AddTicketResolution(context, ticketResolution.Id, ticketResolution.ResolutionDescription, ticketResolution.ResolutionDate, ticketResolution.TicketId);
            }
        }
    }
}





