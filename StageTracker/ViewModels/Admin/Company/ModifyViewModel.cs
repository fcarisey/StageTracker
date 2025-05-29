using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using StageTracker.Services.Data;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Company;

public partial class ModifyViewModel : BaseViewModel, INavigableWithParameter
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private Models.Company? _company;

    private readonly CompanyDataService _companyDataService;

    public ModifyViewModel(INavigationService navigationService, CompanyDataService companyDataService)
    {
        _navigationService = navigationService;
        _companyDataService = companyDataService;
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Models.Company company)
        {
            Company = company;
        }
    }

    [RelayCommand]
    private void ModifyCompany()
    {
        if (Company != null)
            _companyDataService.UpdateCompanyAsync(Company);

        MessageBox.Show($"Company modifié avec succès ! {Company?.Name} - {Company?.Email} - {Company?.Website}", "Modification d'entreprise", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.CompaniesView>();
    }
}
