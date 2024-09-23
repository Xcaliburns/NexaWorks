using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NexaWorks.Models.Entities;
using System.Net.Sockets;

namespace NexaWorks.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        // Ambiguous Name.
        public DbSet<NexaWorks.Models.Entities.Version> Versions { get; set; }
        public DbSet<Compatibility> Compatibilities { get; set; }
        public DbSet<NexaWorks.Models.Entities.OperatingSystem> OperatingSystems { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
       
    }
}
