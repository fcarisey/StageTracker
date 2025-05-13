using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StageTracker.Interfaces.Services;

namespace StageTracker.Services;

public class AuthService : IAuthService
{
    private readonly IUserSessionService _userSessionService;
    private readonly INavigationService _navigationService;

    public AuthService(IUserSessionService userSessionService, INavigationService navigationService)
    {
        _userSessionService = userSessionService;
        _navigationService = navigationService;
    }

    public void Authenticate(string username, string password)
    {
        if (username == "admin" && password == "admin")
        {
            _userSessionService.IsAdmin = true;
            _userSessionService.IsTeacher = false;
        }
        else if (username == "prof" && password == "prof")
        {
            _userSessionService.IsTeacher = true;
            _userSessionService.IsAdmin = false;
        }
        else
        {
            MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        _userSessionService.Username = username;
        
        
        if (_userSessionService.IsAdmin)
        {
            _navigationService.NavigateTo<Views.Admin.ClassesView>();
        }
        else if (_userSessionService.IsTeacher)
        {
            _navigationService.NavigateTo<Views.Teacher.ApplicationsView>();
        }
    }

    public void Logout()
    {
        _userSessionService.Username = string.Empty;
        _userSessionService.IsAdmin = false;
        _userSessionService.IsTeacher = false;
        _navigationService.NavigateTo<Views.LoginView>();
    }

    public bool IsAuthenticated()
    {
        return !string.IsNullOrEmpty(_userSessionService.Username);
    }
}
