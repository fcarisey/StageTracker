using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using StageTracker.Interfaces.Services;
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

    private IAuthService _authService;

    private IUserSessionService _session;

    public LoginViewModel(IUserSessionService session, IServiceProvider provider, IAuthService authService)
    {
        Title = "Login";
        Description = "Login to your account";
        _provider = provider;
        _session = session;
        _authService = authService;
    }

    [RelayCommand]
    private void Login()
    {
        if (string.IsNullOrEmpty(Identifiant) || string.IsNullOrEmpty(Password))
        {
            return;
        }

        _authService.Authenticate(Identifiant, Password);
    }

}

