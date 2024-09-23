namespace NexaWorks.Models.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }

        // Relations
        public int UserID { get; set; }
       
    }
}
