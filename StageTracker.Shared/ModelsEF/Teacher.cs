using System.ComponentModel.DataAnnotations.Schema;

namespace StageTracker.Shared.ModelsEF;

public class Teacher
{
    public int? Id { get; set; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }

    public int? ClasseId { get; set; }
    public Classe? Classe { get; set; }

    [NotMapped]
    public string FullName => $"{LastName} {FirstName}";
}
