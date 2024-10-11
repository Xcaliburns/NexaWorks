using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NexaWorks.Models.Entities;
using OperatingSystem = NexaWorks.Models.Entities.OperatingSystem;
using Version = NexaWorks.Models.Entities.Version;


namespace NexaWorks.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<OperatingSystem> OperatingSystems { get; set; }
        public DbSet<ProductVersionOperatingSystem> ProductVersionOperatingSystems { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketResolution> TicketResolutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and cascade behaviors
            modelBuilder.Entity<ProductVersionOperatingSystem>()
                .HasOne(pvos => pvos.Product)
                .WithMany(p => p.ProductVersionOperatingSystems)
                .HasForeignKey(pvos => pvos.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductVersionOperatingSystem>()
                .HasOne(pvos => pvos.Version)
                .WithMany(v => v.ProductVersionOperatingSystems)
                .HasForeignKey(pvos => pvos.VersionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductVersionOperatingSystem>()
                .HasOne(pvos => pvos.OperatingSystem)
                .WithMany(os => os.ProductVersionOperatingSystems)
                .HasForeignKey(pvos => pvos.OperatingSystemId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.ProductVersionOperatingSystem)
                .WithMany(pvos => pvos.Tickets)
                .HasForeignKey(t => t.ProductVersionOperatingSystemId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
