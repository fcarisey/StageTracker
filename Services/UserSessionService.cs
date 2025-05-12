using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTracker.Services
{
    public partial class UserSessionService : ObservableObject
    {
        [ObservableProperty]
        public string _username;

        [ObservableProperty]
        public bool _isAdmin;

        [ObservableProperty]
        public bool _isTeacher;

        public UserSessionService()
        {
            Username = string.Empty;
            IsAdmin = false;
            IsTeacher = false;
        }
    }
}
