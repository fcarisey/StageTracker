using CommunityToolkit.Mvvm.ComponentModel;
using StageTracker.Interfaces.Services;
using StageTracker.Shared.Enum;

namespace StageTracker.Services
{
    public partial class UserSessionService : ObservableObject, IUserSessionService
    {
        [ObservableProperty]
        public string _username;

        private ERoles _role;
        public ERoles Role 
        {
            get => _role;
            set 
            { 
                _role = value; 
                IsAdmin = _role == ERoles.ADMIN;
                IsTeacher = _role == ERoles.TEACHER;
            } 
        }

        [ObservableProperty]
        private bool _isAdmin;

        [ObservableProperty]
        private bool _isTeacher;

        public int? ClasseId { get; set; }

        public UserSessionService()
        {
            Username = string.Empty;
            IsAdmin = false;
            IsTeacher = false;
        }
    }
}
