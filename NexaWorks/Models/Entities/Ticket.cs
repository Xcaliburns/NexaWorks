using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Title { get; set; } = string.Empty; // Initialize to avoid nullability issues
        public string Description { get; set; } = string.Empty; // Initialize to avoid nullability issues
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }

        // Foreign Keys
       
        [ForeignKey("Version")]
        public int VersionID { get; set; }

        // Navigation Properties
        public Version Version { get; set; } = null!; // Use null-forgiving operator


       
    }
}
