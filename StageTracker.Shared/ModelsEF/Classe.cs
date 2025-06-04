using System.ComponentModel.DataAnnotations.Schema;

namespace StageTracker.Shared.ModelsEF;

public class Classe
{
    public int? Id { get; set; }
    public required string Name { get; set; }

    public List<Student> Students { get; set; } = [];

    public Teacher? Teacher { get; set; }

    [NotMapped]
    public bool HasStudents => Students.Count > 0;

}
