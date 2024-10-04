using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models.Entities
{
    public class TIcketResolution
    {
        public int Id { get; set; }
        public string ResolutionDescription { get; set; }
        public DateTime ResolutionDate { get; set; }
        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
