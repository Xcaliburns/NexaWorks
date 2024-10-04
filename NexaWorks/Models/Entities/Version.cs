using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models.Entities
{
    public class Version
    {
        public int Id { get; set; }
        public float Name { get; set; }    
        
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<ProductVersionOperatingSystem> ProductVersionOperatingSystems { get; set; }

    }
}
