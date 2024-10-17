using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }
        public string ProblemDescription { get; set; }

        [ForeignKey("ProductVersionOperatingSystem")]
        public int ProductVersionOperatingSystemId { get; set; }
        public ProductVersionOperatingSystem ProductVersionOperatingSystem { get; set; }

        public TicketResolution TicketResolution { get; set; }
    }
}
