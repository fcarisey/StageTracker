using StageTracker.Shared.Enums;
using Microsoft.AspNetCore.Components.Forms;

namespace StageTracker.Shared.ModelsDtoWpfWeb;

public record class StudentApplyDto
{
    public EApplicationStatus Status { get; set; }
    public string? MessageToRecruiter { get; set; }
    public IBrowserFile? CV { get; set; }
    public int StudentId { get; set; }
    public int OfferId { get; set; }
}
