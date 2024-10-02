

using NexaWorks.Models.Entities;
using OperatingSystem = NexaWorks.Models.Entities.OperatingSystem;
using Version = NexaWorks.Models.Entities.Version;

public class Ticket
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ResolutionDate{ get; set; }
    public bool Status { get; set; }
    public string? Resolution { get; set; }

    // Foreign key
   public int ProductVersionOperatingSystemId { get; set; }
    public ProductVersionOperatingSystem ProductVersionOperatingSystem { get; set; }
}
