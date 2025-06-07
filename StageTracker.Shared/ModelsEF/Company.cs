using System.ComponentModel.DataAnnotations.Schema;

namespace StageTracker.Shared.ModelsEF;

public class Company
{
    public int? Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }

    public string? PhoneNumber { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string? Website { get; set; } = string.Empty;

    public List<Internship> Internships { get; set; } = [];

    [NotMapped]
    public bool HasInternship => Internships.Count > 0;
}
