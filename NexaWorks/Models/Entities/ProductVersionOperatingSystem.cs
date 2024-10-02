using Microsoft.EntityFrameworkCore;
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
        public Version Version { get; set; }
        public Product Product { get; set; }
        public OperatingSystem OperatingSystem { get; set; }
    }
}
