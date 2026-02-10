
using System.Text.Json;

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
    public int Priority { get; set; } = 0; // 0 = Low, 3 = Medium, 5 = High

    public string CommentsJson { get; set; } = "[]";

    public List<string> GetComments()
    {
        return JsonSerializer.Deserialize<List<string>>(CommentsJson)
               ?? new List<string>();
    }

    public void AddComment(string comment)
    {
        var comments = GetComments();
        comments.Add(comment);
        CommentsJson = JsonSerializer.Serialize(comments);
    }
}
