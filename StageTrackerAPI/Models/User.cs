using System.Security;

namespace StageTrackerAPI.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public byte[] Password { get; set; } = default!;
    public byte[] Salt { get; set; } = default!;
    public bool IsAdmin { get; set; } = false;
    public bool IsTeacher { get; set; } = false;
    public int? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
}
