using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models.Entities
{
    public class Compatibility
    {

        public int CompatibilityID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [ForeignKey("OperatingSystem")]
        public int OperatingSystemID { get; set; }

        // Relations
        public Product Product { get; set; }
        public OperatingSystem OperatingSystem { get; set; }


    }
}
