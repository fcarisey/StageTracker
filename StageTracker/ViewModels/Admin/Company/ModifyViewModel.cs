using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.WPF.Interfaces.Services;
using StageTracker.WPF.Interfaces.ViewModels;
using StageTracker.WPF.Services.Data;
using System.Windows;

namespace StageTracker.WPF.ViewModels.Admin.Company;

public partial class ModifyViewModel(INavigationService navigationService, CompanyDataService companyDataService) : BaseViewModel, INavigableWithParameter
{
    private readonly INavigationService _navigationService = navigationService;

    [ObservableProperty]
    private Shared.ModelsEF.Company? _company;

    private readonly CompanyDataService _companyDataService = companyDataService;

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Shared.ModelsEF.Company company)
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
