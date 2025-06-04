using System.ComponentModel.DataAnnotations.Schema;

namespace StageTracker.Shared.ModelsEF;

public class Student
{
    public int? Id { get; set; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public int? ClasseId { get; set; }
    public Classe? Classe { get; set; }

    public List<Internship> Internships { get; set; } = [];

    public List<Application> Applications { get; set; } = [];

    public List<Remark> Remarks { get; set; } = [];

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    [NotMapped]
    public bool HasInternship => Internships.Count > 0;

    [NotMapped]
    public bool HasApplication => Applications.Count > 0;

    [NotMapped]
    public bool HasRemark => Remarks.Count > 0;

}
