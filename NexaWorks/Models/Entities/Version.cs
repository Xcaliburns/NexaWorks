using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models.Entities
{
    public class Version
    {
        public int VersionID { get; set; }
        public string VersionName { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Relations
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
