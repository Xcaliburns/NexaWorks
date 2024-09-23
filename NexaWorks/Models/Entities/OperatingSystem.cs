namespace NexaWorks.Models.Entities
{
    public class OperatingSystem
    {
        public int OperatingSystemID { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        // Relations
        public ICollection<Compatibility> Compatibilities { get; set; }
    }
}
