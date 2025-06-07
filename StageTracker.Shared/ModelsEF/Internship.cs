namespace StageTracker.Shared.ModelsEF;

public class Internship
{
    public int? Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public required string Address { get; set; } = string.Empty;

    public int StudentId { get; set; }
    public required Student Student { get; set; }

    public int CompanyId { get; set; }
    public required Company Company { get; set; }
}
