namespace StageTrackerAPI.Models;

public class Application
{
    public required int Id { get; set; }
    public DateTime AppliedAt { get; set; }

    public required string Status { get; set; }

    public string? MessageToRecruiter { get; set; }

    public int StudentId { get; set; }
    public required Student Student { get; set; }

    public int InternshipId { get; set; }
    public required IntershipDto Internship { get; set; }
}
