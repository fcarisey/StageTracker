using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Services.Data;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Company;

public partial class AddViewModel(INavigationService navigationService, CompanyDataService companyDataService) : BaseViewModel
{
    private readonly INavigationService _navigationService = navigationService;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _address = string.Empty;

    [ObservableProperty]
    private string _phoneNumber = string.Empty;

    [ObservableProperty]
    private string _website = string.Empty;

    private readonly CompanyDataService _companyDataService = companyDataService;

    [RelayCommand]
    private void AddCompany()
    {
        _companyDataService.AddCompanyAsync(new Shared.ModelsEF.Company()
        {
            Name = Name,
            Email = Email,
            Address = Address,
            PhoneNumber = PhoneNumber,
            Website = Website
        });
        MessageBox.Show($"Companie créé avec succès ! {Name} - {Email} - {Address}", "Création d'une campanie", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.CompaniesView>();
    }
}
