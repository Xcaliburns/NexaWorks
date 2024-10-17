namespace NexaWorks.Models.Entities
{
    public class OperatingSystem
    {
        public int OperatingSystemId { get; set; }
        public string OperatingSystemName { get; set; }

        public ICollection<ProductVersionOperatingSystem> ProductVersionOperatingSystems { get; set; }

    }
}
