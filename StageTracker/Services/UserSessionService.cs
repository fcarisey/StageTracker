using CommunityToolkit.Mvvm.ComponentModel;
using StageTracker.Interfaces.Services;

namespace StageTracker.Services
{
    public partial class UserSessionService : ObservableObject, IUserSessionService
    {
        [ObservableProperty]
        public string _username;

        [ObservableProperty]
        public bool _isAdmin;

        [ObservableProperty]
        public bool _isTeacher;

        public int? ClasseId { get; set; }

        public UserSessionService()
        {
            Username = string.Empty;
            IsAdmin = false;
            IsTeacher = false;
        }
    }
}
