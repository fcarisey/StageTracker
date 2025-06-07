using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.WPF.Interfaces.Services;
using StageTracker.WPF.Services.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace StageTracker.WPF.ViewModels.Admin;

public partial class CampaniesViewModel : BaseViewModel
{
    private ObservableCollection<Shared.ModelsEF.Company> _companies = [];

    [ObservableProperty]
    private ICollectionView _filteredCompanies = default!;

    private readonly INavigationService _navigationService;

    private readonly CompanyDataService _companyDataService;

    public CampaniesViewModel(INavigationService navigationService, CompanyDataService companyDataService)
    {
        _navigationService = navigationService;
        _companyDataService = companyDataService;

        LoadCompaniesAsync();
    }

    private async void LoadCompaniesAsync()
    {
        var companies = await _companyDataService.GetAllCompaniesAsync();
        _companies = new ObservableCollection<Shared.ModelsEF.Company>(companies);

        FilteredCompanies = CollectionViewSource.GetDefaultView(_companies);
    }

    [RelayCommand]
    public void OnTextChanged(string searchTerms)
    {
        if (!string.IsNullOrEmpty(searchTerms) && searchTerms.Length > 0)
        {
            searchTerms = searchTerms.Trim();
            FilteredCompanies.Filter = x =>
            {
                if (x is Shared.ModelsEF.Company company)
                {
                    if (company != null)
                    {
                        return company.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                               (company.Email?.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ?? false) ||
                               (company.PhoneNumber?.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ?? false) ||
                               company.Address.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase);
                    }
                }

                return false;
            };

            FilteredCompanies.Refresh();
        }
        else
        {
            FilteredCompanies.Filter = null;
            FilteredCompanies.Refresh();
        }
    }

    [RelayCommand]
    public void AddCompany()
    {
        _navigationService.NavigateTo<Views.Admin.Company.AddView>();
    }

    [RelayCommand]
    public void ModifyCompany(Shared.ModelsEF.Company company)
    {
        _navigationService.NavigateTo<Views.Admin.Company.ModifyView>(company);
    }

    [RelayCommand]
    public void DeleteCompany(Shared.ModelsEF.Company company)
    {
        MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer {company.Name}", "Suppression de l'entreprise", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            _companyDataService.DeleteCompanyAsync(company);
            _companies.Remove(company);
            FilteredCompanies.Refresh();
        }
    }
}
