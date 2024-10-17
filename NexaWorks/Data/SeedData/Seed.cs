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
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            context.Database.EnsureCreated();

            try
            {
                if (!context.OperatingSystems.Any())
                {
                    using var transaction = context.Database.BeginTransaction();
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
                throw;
            }

            try
            {
                if (!context.Products.Any())
                {
                    using var transaction = context.Database.BeginTransaction();
                    await AddProductsAsync(context,
                        (1, "Trader en Herbe"),
                        (2, "Maître des Investissements"),
                        (3, "Planificateur d’Entraînement"),
                        (4, "Planificateur d’Anxiété Sociale")
                    );
                    transaction.Commit();
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
                    using var transaction = context.Database.BeginTransaction();
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while seeding the Versions table: {ex.Message}");
                throw;
            }

            try
            {
                if (!context.ProductVersionOperatingSystems.Any())
                {
                    using var transaction = context.Database.BeginTransaction();

                    await AddProductVersionOperatingSystemsAsync(context, 1, 1, 1, [1, 3]); // version 1.0
                    await AddProductVersionOperatingSystemsAsync(context, 3, 1, 2, [1, 2, 3]); // version 1.1
                    await AddProductVersionOperatingSystemsAsync(context, 6, 1, 3, [1, 2, 3, 4, 5, 6]); // version 1.2
                    await AddProductVersionOperatingSystemsAsync(context, 12, 1, 4, [2, 3, 4, 6]); // version 1.3

                    await AddProductVersionOperatingSystemsAsync(context, 16, 2, 5, [2, 5]); // version 1.0
                    await AddProductVersionOperatingSystemsAsync(context, 18, 2, 6, [2, 4, 5]); // version 2.0
                    await AddProductVersionOperatingSystemsAsync(context, 21, 2, 7, [2, 3, 4, 5]); // version 2.1

                    await AddProductVersionOperatingSystemsAsync(context, 25, 3, 8, [1, 2]); // version 1.0
                    await AddProductVersionOperatingSystemsAsync(context, 27, 3, 9, [1, 2, 3, 4, 5, 6]); // version 1.1
                    await AddProductVersionOperatingSystemsAsync(context, 33, 3, 10, [2, 3, 4, 5]); // version 2.0

                    await AddProductVersionOperatingSystemsAsync(context, 37, 4, 11, [2, 3, 4, 5]); // version 1.0
                    await AddProductVersionOperatingSystemsAsync(context, 41, 4, 12, [2, 3, 4, 5]); // version 1.1

                    transaction.Commit();
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
                    using var transaction = context.Database.BeginTransaction();
                    await AddTicketsAsync(context,
               (1, new DateTime(2024, 9, 1), true, "Dès que je clique sur l’icône pour ouvrir l’application, elle s’affiche pendant une seconde puis disparaît. J’ai essayé de redémarrer mon ordinateur, mais le problème persiste. Cela a commencé après que mon ordinateur a fait une mise à jour. ", 1),
               (2, new DateTime(2024, 9, 2), false, "Lorsque j’essaie de me connecter, un message d’erreur s’affiche indiquant “Connexion au serveur échouée”. J’ai vérifié ma connexion Internet et elle fonctionne correctement. \r\n\r\nLe problème persiste même après avoir redémarré mon Mac. ", 6),
               (3, new DateTime(2024, 9, 3), true, "Lorsque j’essaie de synchroniser mes données, un message d’erreur s’affiche indiquant “Échec de la synchronisation des données”. J’ai vérifié ma connexion Internet et elle fonctionne correctement. \r\n\r\nLe problème persiste même après avoir redémarré l’application et mon téléphone. ", 8),
               (4, new DateTime(2024, 9, 4), false, "Je ne reçois aucune notification de l’application, même si elles sont activées dans les paramètres. J’ai vérifié les paramètres de notification sur mon iPhone et tout semble correct. \r\n\r\nLe problème persiste même après avoir redémarré mon iPhone. ", 11),
               (5, new DateTime(2024, 9, 5), true, "L’application ne se lance pas correctement sur certaines distributions Linux. Des erreurs de dépendances manquantes sont signalées lors de l’installation. \r\n\r\nLe problème persiste malgré plusieurs tentatives de réinstallation. ", 5),
               (6, new DateTime(2024, 9, 6), false, "L’application met beaucoup de temps à charger les données. Les actions prennent plusieurs secondes à se réaliser, ce qui rend l’utilisation difficile. \r\n\r\nLe problème persiste même après avoir redémarré l’ordinateur. ", 2),
               (7, new DateTime(2024, 9, 7), true, "Les graphiques ne s’affichent pas correctement, avec des éléments manquants ou déformés. Le problème survient sur plusieurs types de graphiques. \r\n\r\nJ’ai essayé de réinstaller l’application, mais le problème persiste. ", 9),
               (8, new DateTime(2024, 9, 8), false, "L’application se ferme automatiquement lorsque j’essaie d’ajouter un nouvel événement. J’ai essayé de redémarrer mon téléphone, mais le problème persiste. \r\n\r\nLe problème est apparu après la dernière mise à jour de l’application. ", 12),
               (9, new DateTime(2024, 9, 9), true, "Impossible de se connecter à l’API, un message d’erreur s’affiche indiquant “Échec de la connexion à l’API”. J’ai vérifié ma connexion Internet et elle fonctionne correctement. \r\n\r\nLe problème persiste même après avoir réinstallé l’application. ", 4),
               (10, new DateTime(2024, 9, 10), false, "Les rendements calculés par l’application sont incorrects. \r\n\r\nLes résultats varient de manière incohérente à chaque calcul. \r\n\r\nLe problème persiste malgré plusieurs tentatives de réinstallation. ", 7),
               (11, new DateTime(2024, 9, 11), true, "Les données ne sont pas sauvegardées correctement, entraînant des pertes d’informations. \r\n\r\nLe problème survient de manière aléatoire, sans message d’erreur. \r\n\r\nJ’ai essayé de réinstaller l’application, mais le problème persiste. ", 3),
               (12, new DateTime(2024, 9, 12), false, " les événements ne se mettent pas à jour correctement après modification. \r\n\r\nLes modifications apportées ne sont pas enregistrées. \r\n\r\nLe problème persiste même après avoir redémarré l’application. ", 10),
               (13, new DateTime(2024, 9, 13), true, " L’application est très lente et met du temps à répondre aux commandes. \r\n\r\nLe problème persiste même après avoir redémarré le téléphone. \r\n\r\nCela rend l’utilisation de l’application très difficile. ", 13),
               (14, new DateTime(2024, 9, 14), false, "Les données ne se synchronisent pas correctement entre les appareils. \r\n\r\nCertaines informations sont manquantes ou incorrectes après la synchronisation. \r\n\r\nLe problème persiste malgré plusieurs tentatives de synchronisation. ", 14),
               (15, new DateTime(2024, 9, 15), true, "L’application ne fonctionne pas correctement sur certaines distributions Linux. \r\n\r\nDes erreurs apparaissent lors de l’installation et de l’utilisation. \r\n\r\nLe problème persiste malgré plusieurs tentatives de réinstallation. ", 15),
               (16, new DateTime(2024, 9, 16), false, "Les notifications ne s’affichent pas correctement. \r\n\r\nJ’ai vérifié les paramètres de notification et tout semble correct. \r\n\r\nle problème persiste même après avoir redémarré l’ordinateur. ", 16),
               (17, new DateTime(2024, 9, 17), true, "impossible de se connecter au serveur, un message d’erreur s’affiche. \r\n\r\nJ’ai vérifié ma connexion Internet et elle fonctionne correctement. \r\n\r\nLe problème persiste même après avoir redémarré l’application. ", 17),
               (18, new DateTime(2024, 9, 18), false, " Les rendements calculés par l’application sont incorrects. \r\n\r\nLes résultats varient de manière incohérente à chaque calcul. \r\n\r\nLe problème persiste malgré plusieurs tentatives de réinstallation ", 18),
               (19, new DateTime(2024, 9, 19), true, "Les données ne sont pas sauvegardées correctement, entraînant des pertes d’informations. \r\n\r\nLe problème survient de manière aléatoire, sans message d’erreur. \r\n\r\nJ’ai essayé de réinstaller l’application, mais le problème persiste. ", 19),
               (20, new DateTime(2024, 9, 20), false, "Les événements ne se mettent pas à jour correctement après modification. \r\n\r\nLes modifications apportées ne sont pas enregistrées. \r\n\r\nLe problème persiste même après avoir redémarré l’application. ", 20),
               (21, new DateTime(2024, 9, 21), true, " L’application est très lente et met du temps à répondre aux commandes. \r\n\r\nLe problème persiste même après avoir redémarré l’ordinateur.Cela rend l’utilisation de l’application très difficile. ", 21),
               (22, new DateTime(2024, 9, 22), false, "Les données ne se synchronisent pas correctement entre les appareils. \r\n\r\nCertaines informations sont manquantes ou incorrectes après la synchronisation. \r\n\r\nLe problème persiste malgré plusieurs tentatives de synchronisation. ", 22),
               (23, new DateTime(2024, 9, 24), false, "Les rappels ne s’affichent pas correctement. \r\n\r\nJ’ai vérifié les paramètres de notification et tout semble correct. \r\n\r\nLe problème persiste même après avoir redémarré l’ordinateur. ", 23),
               (24, new DateTime(2024, 9, 25), true, "Impossible de se connecter à l’API de trading, un message d’erreur s’affiche. \r\n\r\nJ’ai vérifié ma connexion Internet et elle fonctionne correctement. \r\n\r\nLe problème persiste même après avoir réinstallé l’application. ", 24),
               (25, new DateTime(2024, 9, 26), false, "Les rendements calculés par l’application sont incorrects. \r\n\r\nLes résultats varient de manière incohérente à chaque calcul. \r\n\r\nLe problème persiste malgré plusieurs tentatives de réinstallation. ", 25)
           );
                    transaction.Commit();
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
                    using var transaction = context.Database.BeginTransaction();
                    await AddTicketResolutionsAsync(context,
                          (1, "Correction d’un bug lié à la gestion de la mémoire qui causait un plantage lors de l’ouverture de l’application. ", new DateTime(2024, 9, 2), 1),
                          (2, "Correction de l’API de synchronisation.", new DateTime(2024, 9, 4), 3),
                          (3, "Mise à jour de la compatibilité pour inclure les dépendances manquantes et assurer le bon fonctionnement sur les distributions Linux concernées.. ", new DateTime(2024, 9, 6), 5),
                          (4, "Correction du rendu graphique pour résoudre les problèmes d’affichage. ", new DateTime(2024, 9, 8), 7),
                          (5, "Mise à jour des autorisations utilisateur pour corriger le problème de connexion. ", new DateTime(2024, 9, 10), 9),
                          (6, "Correction du module de sauvegarde pour assurer la fiabilité des sauvegardes. ", new DateTime(2024, 9, 12), 11),
                          (7, "Optimisation du code pour améliorer les performances. ", new DateTime(2024, 9, 14), 13),
                          (8, "Mise à jour de la compatibilité pour assurer le bon fonctionnement sur les distributions Linux concernées. ", new DateTime(2024, 9, 16), 15),
                          (9, "Mise à jour du serveur pour corriger le problème de connexion. ", new DateTime(2024, 9, 18), 17),
                          (10, "Correction du module de sauvegarde pour assurer la fiabilité des sauvegardes. ", new DateTime(2024, 9, 20), 19),
                          (11, "Optimisation du code pour améliorer les performances. ", new DateTime(2024, 9, 22), 21),
                          (12, "Mise à jour des autorisations utilisateur pour corriger le problème de connexion.", new DateTime(2024, 9, 26), 24));
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while seeding the TicketResolutions table: {ex.Message}");
                throw;
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
                    OperatingSystemId = os.Id,
                    OperatingSystemName = os.Name
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
                ProductId = productId,
                ProductName = productName
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
                    ProductId = product.Id,
                    ProductName = product.Name
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
                VersionId = versionId,
                ProductId = productId,
                VersionName = versionName
            });

            await context.SaveChangesAsync();

            // Disable explicit value insertion for the identity column
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Versions OFF");
        }

        // Utilitaire pour ajouter un ensemble de Version
       

        private static async Task AddVersionsAsync(ApplicationDbContext context, params (int Id, int ProductId, float Name)[] versions)
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Versions ON");

            foreach (var version in versions)
            {
                context.Versions.Add(new Version
                {
                    VersionId = version.Id,
                    ProductId = version.ProductId,
                    VersionName = version.Name
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
                ProductVersionOperatingSystemId = id,
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
                TicketId = ticketId,
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
                    TicketId = ticket.Id,
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
                TicketResolutionId = ticketResolutionId,
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
                    TicketResolutionId = ticketResolution.Id,
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





