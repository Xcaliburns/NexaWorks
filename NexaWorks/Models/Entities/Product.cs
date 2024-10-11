using NexaWorks.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace NexaWorks.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductVersionOperatingSystem> ProductVersionOperatingSystems { get; set; }
    }
}

