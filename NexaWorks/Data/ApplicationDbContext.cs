using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NexaWorks.Models.Entities;


namespace NexaWorks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<NexaWorks.Models.Entities.Version> Versions { get; set; }
        public DbSet<ProductVersionOperatingSystem> ProductVersionOperatingSystems { get; set; }
        public DbSet<NexaWorks.Models.Entities.OperatingSystem> OperatingSystems { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVersionOperatingSystem>()
                .HasOne(pvos => pvos.Version)
                .WithMany()
                .HasForeignKey(pvos => pvos.VersionId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProductVersionOperatingSystem>()
                .HasOne(pvos => pvos.OperatingSystem)
                .WithMany()
                .HasForeignKey(pvos => pvos.OperatingSystemId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProductVersionOperatingSystem>()
                .HasOne(pvos => pvos.Product)
                .WithMany()
                .HasForeignKey(pvos => pvos.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
