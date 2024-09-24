using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexaWorks.Models.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
