using Microsoft.EntityFrameworkCore;
using OperatingSystem = NexaWorks.Models.Entities.OperatingSystem;
using Product = NexaWorks.Models.Entities.Product;
using ProductVersionOperatingSystem = NexaWorks.Models.Entities.ProductVersionOperatingSystem;
using Ticket = NexaWorks.Models.Entities.Ticket;
using TicketResolution = NexaWorks.Models.Entities.TicketResolution;
using Version = NexaWorks.Models.Entities.Version;


namespace NexaWorks.Data.SeedData
{
    public class Seed
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();

                try
                {
                    if (!context.OperatingSystems.Any())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            await AddOperatingSystemsAsync(context,
                               (1, "Linux"),
                               (2, "macOS"),
                               (3, "Windows"),
                               (4, "Android"),
                               (5, "iOS"),
                               (6, "Windows Mobile")
                            );
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
                    throw;
                }

                try
                {
                    if (!context.Products.Any())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            await AddProductsAsync(context,
                                (1, "Trader en Herbe"),
                                (2, "Maître des Investissements"),
                                (3, "Planificateur d’Entraînement"),
                                (4, "Planificateur d’Anxiété Sociale")
                            );
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
                            await AddVersionsAsync(context,
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

                            await AddProductVersionOperatingSystemsAsync(context, 1, 1, 1, new[] { 1, 3 }); // version 1.0
                            await AddProductVersionOperatingSystemsAsync(context, 3, 1, 2, new[] { 1, 2, 3 }); // version 1.1
                            await AddProductVersionOperatingSystemsAsync(context, 6, 1, 3, new[] { 1, 2, 3, 4, 5, 6 }); // version 1.2
                            await AddProductVersionOperatingSystemsAsync(context, 12, 1, 4, new[] { 2, 3, 4, 6 }); // version 1.3

                            await AddProductVersionOperatingSystemsAsync(context, 16, 2, 5, new[] { 2, 5 }); // version 1.0
                            await AddProductVersionOperatingSystemsAsync(context, 18, 2, 6, new[] { 2, 4, 5 }); // version 2.0
                            await AddProductVersionOperatingSystemsAsync(context, 21, 2, 7, new[] { 2, 3, 4, 5 }); // version 2.1

                            await AddProductVersionOperatingSystemsAsync(context, 25, 3, 8, new[] { 1, 2 }); // version 1.0
                            await AddProductVersionOperatingSystemsAsync(context, 27, 3, 9, new[] { 1, 2, 3, 4, 5, 6 }); // version 1.1
                            await AddProductVersionOperatingSystemsAsync(context, 33, 3, 10, new[] { 2, 3, 4, 5 }); // version 2.0

                            await AddProductVersionOperatingSystemsAsync(context, 37, 4, 11, new[] { 2, 3, 4, 5 }); // version 1.0
                            await AddProductVersionOperatingSystemsAsync(context, 41, 4, 12, new[] { 2, 3, 4, 5 }); // version 1.1

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
                            await AddTicketsAsync(context,
                       (1, new DateTime(2024, 9, 1), true, "L’application plante lors de l’ouverture.", 1),
                       (2, new DateTime(2024, 9, 2), false, "Problème de connexion au serveur.", 6),
                       (3, new DateTime(2024, 9, 3), true, "Erreur lors de la synchronisation des données.", 8),
                       (4, new DateTime(2024, 9, 4), false, "Notifications ne fonctionnent pas.", 11),
                       (5, new DateTime(2024, 9, 5), true, "Problème de compatibilité avec la version Linux.", 5),
                       (6, new DateTime(2024, 9, 6), false, "Lenteur de l’application.", 2),
                       (7, new DateTime(2024, 9, 7), true, "Problème d’affichage des graphiques.", 9),
                       (8, new DateTime(2024, 9, 8), false, "Crash lors de l’ajout d’un événement.", 12),
                       (9, new DateTime(2024, 9, 9), true, "Problème de connexion à l’API.", 4),
                       (10, new DateTime(2024, 9, 10), false, "Erreur de calcul des rendements.", 7),
                       (11, new DateTime(2024, 9, 11), true, "Problème de sauvegarde des données.", 3),
                       (12, new DateTime(2024, 9, 12), false, "Problème de mise à jour des événements.", 10),
                       (13, new DateTime(2024, 9, 13), true, "Problème de performance.", 13),
                       (14, new DateTime(2024, 9, 14), false, "Problème de synchronisation des données.", 14),
                       (15, new DateTime(2024, 9, 15), true, "Problème de compatibilité avec Linux.", 15),
                       (16, new DateTime(2024, 9, 16), false, "Problème de notification.", 16),
                       (17, new DateTime(2024, 9, 17), true, "Problème de connexion au serveur.", 17),
                       (18, new DateTime(2024, 9, 18), false, "Problème de calcul des rendements.", 18),
                       (19, new DateTime(2024, 9, 19), true, "Problème de sauvegarde des données.", 19),
                       (20, new DateTime(2024, 9, 20), false, "Problème de mise à jour des événements.", 20),
                       (21, new DateTime(2024, 9, 21), true, "Problème de performance.", 21),
                       (22, new DateTime(2024, 9, 22), false, "Problème de synchronisation des données.", 22),
                       (23, new DateTime(2024, 9, 24), false, "Problème de notification des rappels.", 23),
                       (24, new DateTime(2024, 9, 25), true, "Problème de connexion à l’API de trading.", 24),
                       (25, new DateTime(2024, 9, 26), false, "Problème de calcul des rendements.", 25)
                   );
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
                            await AddTicketResolutionsAsync(context,
                                  (1, "Résolu en redémarrant l'application", new DateTime(2024, 9, 2), 1),
                                  (2, "Mise à jour de l'application", new DateTime(2024, 9, 4), 3),
                                  (3, "Réinstallation de l'application", new DateTime(2024, 9, 6), 5),
                                  (4, "Correction du bug dans le code", new DateTime(2024, 9, 8), 7),
                                  (5, "Mise à jour du système d'exploitation", new DateTime(2024, 9, 10), 9),
                                  (6, "Augmentation des ressources serveur", new DateTime(2024, 9, 12), 11),
                                  (7, "Optimisation de la base de données", new DateTime(2024, 9, 14), 13),
                                  (8, "Correction des permissions", new DateTime(2024, 9, 16), 15),
                                  (9, "Mise à jour des dépendances", new DateTime(2024, 9, 18), 17),
                                  (10, "Optimisation de l'API", new DateTime(2024, 9, 20), 19),
                                  (11, "Correction du bug dans le code", new DateTime(2024, 9, 22), 21),
                                  (12, "Mise à jour de l'application", new DateTime(2024, 9, 26), 24)
                            );
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



        // Utilitaire pour ajouter un ensemble de OperatingSystem avec des IDs spécifiés
        private static async Task AddOperatingSystemsAsync(ApplicationDbContext context, params (int Id, string Name)[] operatingSystems)
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT OperatingSystems ON");

            foreach (var os in operatingSystems)
            {
                context.OperatingSystems.Add(new OperatingSystem
                {
                    Id = os.Id,
                    Name = os.Name
                });
            }

            await context.SaveChangesAsync();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT OperatingSystems OFF");
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
        private static async Task AddProductsAsync(ApplicationDbContext context, params (int Id, string Name)[] products)
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON");

            foreach (var product in products)
            {
                context.Products.Add(new Product
                {
                    Id = product.Id,
                    Name = product.Name
                });
            }

            await context.SaveChangesAsync();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products OFF");
        }

        private static async Task AddVersionAsync(ApplicationDbContext context, int versionId, int productId, float versionName)
        {
            // Enable explicit value insertion for the identity column
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Versions ON");

            context.Versions.Add(new Version
            {
                Id = versionId,
                ProductId = productId,
                Name = versionName
            });

            await context.SaveChangesAsync();

            // Disable explicit value insertion for the identity column
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Versions OFF");
        }

        // Utilitaire pour ajouter un ensemble de Version
        //TODO : verifier avec Laala:ici j'ajoute explicitement l'Id pour chaque version
        //cela m'oblige à ajouter les lignes context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets ON");
        //et context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets OFF");

        private static async Task AddVersionsAsync(ApplicationDbContext context, params (int Id, int ProductId, float Name)[] versions)
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Versions ON");

            foreach (var version in versions)
            {
                context.Versions.Add(new Version
                {
                    Id = version.Id,
                    ProductId = version.ProductId,
                    Name = version.Name
                });
            }

            await context.SaveChangesAsync();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Versions OFF");
        }

        // Utilitaire pour ajouter un ProductVersionOperatingSystem
        private static async Task AddProductVersionOperatingSystemAsync(ApplicationDbContext context, int id, int productId, int versionId, int osId)
        {
            // Enable explicit value insertion for the identity column
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductVersionOperatingSystems ON");

            var product = await context.Products.FindAsync(productId);
            var version = await context.Versions.FindAsync(versionId);
            var operatingSystem = await context.OperatingSystems.FindAsync(osId);

            if (product == null || version == null || operatingSystem == null)
            {
                throw new InvalidOperationException("Invalid foreign key reference.");
            }

            context.ProductVersionOperatingSystems.Add(new ProductVersionOperatingSystem
            {
                Id = id,
                ProductId = productId,
                VersionId = versionId,
                OperatingSystemId = osId,
                Product = product,
                Version = version,
                OperatingSystem = operatingSystem
            });

            await context.SaveChangesAsync();

            // Disable explicit value insertion for the identity column
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductVersionOperatingSystems OFF");
        }





        // Utilitaire pour ajouter un ensemble de ProductVersionOperatingSystem
        private static async Task AddProductVersionOperatingSystemsAsync(ApplicationDbContext context, int Id, int productId, int versionId, IEnumerable<int> operatingSystemIds)
        {
            var id = 0;
            foreach (var osId in operatingSystemIds)
            {

                await AddProductVersionOperatingSystemAsync(context, Id++, productId, versionId, osId);
            }
        }


        // Utilitaire pour ajouter un Ticket

        private static async Task AddTicketAsync(ApplicationDbContext context, int ticketId, DateTime creationDate, bool status, string problemDescription, int productVersionOperatingSystemId)
        {
            // Enable explicit value insertion for the identity column
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets ON");

            context.Tickets.Add(new Ticket
            {
                Id = ticketId,
                CreationDate = creationDate,
                Status = status,
                ProblemDescription = problemDescription,
                ProductVersionOperatingSystemId = productVersionOperatingSystemId
            });

            await context.SaveChangesAsync();

            // Disable explicit value insertion for the identity column
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets OFF");
        }

        // Utilitaire pour ajouter un ensemble de Tickets
        private static async Task AddTicketsAsync(ApplicationDbContext context, params (int Id, DateTime CreationDate, bool Status, string ProblemDescription, int ProductVersionOperatingSystemId)[] tickets)
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets ON");

            foreach (var ticket in tickets)
            {
                context.Tickets.Add(new Ticket
                {
                    Id = ticket.Id,
                    CreationDate = ticket.CreationDate,
                    Status = ticket.Status,
                    ProblemDescription = ticket.ProblemDescription,
                    ProductVersionOperatingSystemId = ticket.ProductVersionOperatingSystemId
                });
            }

            await context.SaveChangesAsync();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Tickets OFF");
        }


        // Utilitaire pour ajouter une TicketResolution
        private static async Task AddTicketResolutionAsync(ApplicationDbContext context, int ticketResolutionId, string resolutionDescription, DateTime resolutionDate, int ticketId)
        {
            // Enable explicit value insertion for the identity column
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT TicketResolutions ON");

            context.TicketResolutions.Add(new TicketResolution
            {
                Id = ticketResolutionId,
                ResolutionDescription = resolutionDescription,
                ResolutionDate = resolutionDate,
                TicketId = ticketId
            });

            await context.SaveChangesAsync();

            // Disable explicit value insertion for the identity column
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT TicketResolutions OFF");
        }

        // Utilitaire pour ajouter un ensemble de TicketResolutions
        private static async Task AddTicketResolutionsAsync(ApplicationDbContext context, params (int Id, string ResolutionDescription, DateTime ResolutionDate, int TicketId)[] ticketResolutions)
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT TicketResolutions ON");

            foreach (var ticketResolution in ticketResolutions)
            {
                context.TicketResolutions.Add(new TicketResolution
                {
                    Id = ticketResolution.Id,
                    ResolutionDescription = ticketResolution.ResolutionDescription,
                    ResolutionDate = ticketResolution.ResolutionDate,
                    TicketId = ticketResolution.TicketId
                });
            }

            await context.SaveChangesAsync();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT TicketResolutions OFF");
        }

    }
}





