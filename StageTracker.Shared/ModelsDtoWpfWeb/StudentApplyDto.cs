using StageTracker.Shared.Enums;

namespace StageTracker.Shared.ModelsDtoWpfWeb;

public record class StudentApplyDto
{
    public EApplicationStatus Status { get; set; }
    public string? MessageToRecruiter { get; set; }
    public int StudentId { get; set; }
    public int OfferId { get; set; }
}
