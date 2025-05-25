using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Company;

public partial class AddViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

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

    [ObservableProperty]
    private ObservableCollection<Models.Company> _companies = [];

    private readonly CompanyDataService _companyDataService;

    public AddViewModel(INavigationService navigationService, CompanyDataService companyDataService)
    {
        _navigationService = navigationService;
        _companyDataService = companyDataService;
    }

    [RelayCommand]
    private void AddCompany()
    {
        _companyDataService.AddCompanyAsync(new Models.Company()
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
