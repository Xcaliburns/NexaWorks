namespace NexaWorks.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductVersionOperatingSystem> ProductVersionOperatingSystems { get; set; }
    }
}

