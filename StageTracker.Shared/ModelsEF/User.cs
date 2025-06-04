namespace StageTracker.Shared.ModelsEF;

public class User
{
    public int? Id { get; set; }
    public required string Email { get; set; }
    public required byte[] Password { get; set; }
    public required byte[] Salt { get; set; }

    public required bool IsAdmin { get; set; }
    public required bool IsTeacher { get; set; }

    public int? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
}
