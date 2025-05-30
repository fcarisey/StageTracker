using System.ComponentModel.DataAnnotations.Schema;

namespace StageTrackerAPI.Models;

public class RemarkDto
{
    public int? Id { get; set; }
    public string Message { get; set; } = string.Empty;
    [NotMapped]
    public string OriginalMessage { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    [NotMapped]
    public bool IsEditing { get; set; } = false;
}
