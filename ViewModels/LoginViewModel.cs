using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using StageTracker.Services;
using System.Windows;

namespace StageTracker.ViewModels;

public partial class LoginViewModel : BaseViewModel
{

    [ObservableProperty]
    private string _identifiant = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    private IServiceProvider _provider;

    private UserSessionService _session;

    public LoginViewModel(UserSessionService session, IServiceProvider provider)
    {
        Title = "Login";
        Description = "Login to your account";
        _provider = provider;
        _session = session;
    }

    [RelayCommand]
    private void Login()
    {
        if (string.IsNullOrEmpty(Identifiant) || string.IsNullOrEmpty(Password))
        {
            return;
        }

        // Login admin, prof temporaire
        if (Identifiant == "admin" && Password == "admin") 
        { 
            _session.IsAdmin = true;
            _session.Username = Identifiant;

            var adminTeachers = _provider.GetRequiredService<Views.Admin.TeachersView>();
            ((MainWindow)Application.Current.MainWindow).Page.Navigate(adminTeachers);
        }
        else if (Identifiant == "prof" && Password == "prof")
        { 
            _session.IsTeacher = true;
            _session.Username = Identifiant;

            var studentView = _provider.GetRequiredService<Views.Teacher.StudentsView>();
            ((MainWindow)Application.Current.MainWindow).Page.Navigate(studentView);
        }
        else
        {
            MessageBox.Show("Invalid credentials");
            return;
        }
    }

}

