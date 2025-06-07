using StageTracker.Shared.Enum;

namespace StageTracker.Shared.ModelsEF;

public class Application
{
    public int? Id { get; set; }
    public required DateTime AppliedAt { get; set; }

    public required EApplicationStatus Status { get; set; }

    public string? MessageToRecruiter { get; set; }

    public int StudentId { get; set; }
    public required Student Student { get; set; }

    public int InternshipId { get; set; }
    public required Internship Internship { get; set; }
}
