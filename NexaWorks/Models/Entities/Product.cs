namespace NexaWorks.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public ICollection<ProductVersionOperatingSystem> ProductVersionOperatingSystems { get; set; }
    }
}

