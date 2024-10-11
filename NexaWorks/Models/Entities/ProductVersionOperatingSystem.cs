using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models.Entities
{
    public class ProductVersionOperatingSystem
    {
        public int Id { get; set; }

        [ForeignKey("Version")]
        public int VersionId { get; set; }

        [ForeignKey("OperatingSystem")]
        public int OperatingSystemId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        // Relations
        public required Version Version { get; set; }
        public required Product Product { get; set; }
        public required OperatingSystem OperatingSystem { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
