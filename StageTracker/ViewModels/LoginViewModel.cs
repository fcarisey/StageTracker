using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.WPF.Interfaces.Services;

namespace StageTracker.WPF.ViewModels;

public partial class LoginViewModel : BaseViewModel
{

    [ObservableProperty]
    private string _identifiant = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    private readonly IAuthService _authService;

    public LoginViewModel(IAuthService authService)
    {
        Description = "Login to your account";
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

