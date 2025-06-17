using CommunityToolkit.Mvvm.ComponentModel;
using StageTracker.WPF.Interfaces.Services;
using StageTracker.Shared.Enums;

namespace StageTracker.WPF.Services
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
            Role = ERoles.UNASSIGNED;
            IsAdmin = false;
            IsTeacher = false;
        }
    }
}
