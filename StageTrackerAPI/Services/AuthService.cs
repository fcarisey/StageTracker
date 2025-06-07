using System.Security.Cryptography;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using StageTrackerAPI.Data;
using StageTrackerAPI.Helpers;
using StageTrackerAPI.Interfaces.Services;

namespace StageTrackerAPI.Services;

public class AuthService(IUserSessionService userSessionService, DefaultDbContext defaultDbContext) : IAuthService
{
    private readonly IUserSessionService _userSessionService = userSessionService;
    private readonly DefaultDbContext _defaultDbContext = defaultDbContext;

    public async void Authenticate(string username, string password)
    {
        Models.User? user = null;
        try
        {
            user = await _defaultDbContext.Users.Include(u => u.Teacher).Where(u => u.Email == username).FirstAsync();
        }
        catch (InvalidOperationException ex)
        {
            // MessageBox.Show($"An error occurred while trying to authenticate. Please try again later. Message : {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (user == null)
        {
            // MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!PasswordHelper.VerifyPasswordHash(password, user.Password, user.Salt))
        {
            //MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        _userSessionService.Username = username;
        _userSessionService.IsAdmin = (bool)user.IsAdmin;
        _userSessionService.IsTeacher = (bool)user.IsTeacher;

        if (_userSessionService.IsAdmin)
        {
            // _navigationService.NavigateTo<Views.Admin.ClassesView>();
        }
        else if (_userSessionService.IsTeacher)
        {
            _userSessionService.ClasseId = user.Teacher?.ClasseId;
            // _navigationService.NavigateTo<Views.Teacher.ApplicationsView>();
        }
    }

    public void Logout()
    {
        _userSessionService.Username = string.Empty;
        _userSessionService.IsAdmin = false;
        _userSessionService.IsTeacher = false;
        //_navigationService.NavigateTo<Views.LoginView>();
    }

    public bool IsAuthenticated()
    {
        return !string.IsNullOrEmpty(_userSessionService.Username);
    }
}
