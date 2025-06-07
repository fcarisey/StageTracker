using StageTrackerAPI.Interfaces.Services;

namespace StageTrackerAPI.Services
{
    public partial class UserSessionService : IUserSessionService
    {
        public string Username { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsTeacher { get; set; }

        public int? ClasseId { get; set; }

        public UserSessionService()
        {
            Username = string.Empty;
            IsAdmin = false;
            IsTeacher = false;
        }
    }
}
