
namespace HelpDesk.Domain.Entities;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? AssignedTo { get; set; }
    public DateTime? ClosedAt { get; set; }
    public bool IsEscalated { get; set; }
    public string Comment { get; internal set; } = string.Empty;

    public List<string> Comments { get; internal set; } = new List<string>();
}
