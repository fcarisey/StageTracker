using StageTracker.Shared.Enum;

namespace StageTracker.Interfaces.Services
{
    public interface IUserSessionService
    {
        string Username { get; set; }
        public ERoles Role { get; set; }
        bool IsAdmin { get; set; }
        bool IsTeacher { get; set; }

        int? ClasseId { get; set; }
    }
}
