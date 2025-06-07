using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using StageTracker.Interfaces.Services;
using StageTracker.Services.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;

namespace StageTracker.ViewModels.Teacher;

public partial class CompaniesViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    private ObservableCollection<Shared.ModelsEF.Company>? _companies;

    [ObservableProperty]
    private ICollectionView _filteredCompanies = default!;

    private readonly CompanyDataService _companyDataService;

    public CompaniesViewModel(INavigationService navigationService, CompanyDataService companyDataService)
    {
        _companyDataService = companyDataService;
        _navigationService = navigationService;

        _ = LoadCompaniesAsync();
    }

    private async Task LoadCompaniesAsync()
    {
        var companies = await _companyDataService.GetAllCompaniesAsync();
        if (companies != null)
            _companies = new ObservableCollection<Shared.ModelsEF.Company>(companies);

        FilteredCompanies = CollectionViewSource.GetDefaultView(_companies);
    }

    [RelayCommand]
    public void NavigateToCompanyShowView(object company)
    {
        if (company == null)
            throw new ArgumentNullException(nameof(company), "Company cannot be null.");

        _navigationService.NavigateTo<Views.Teacher.Company.ShowView>(company);
    }

    [RelayCommand]
    public void ShowCompanyWebsite(string url)
    {
        url = url.Trim();

        try
        {
            ProcessStartInfo psi = new()
            {
                FileName = new Uri(url, UriKind.RelativeOrAbsolute).AbsoluteUri,
                UseShellExecute = true,
            };

            Process.Start(psi);
        }
        catch (Exception ex) when (ex is InvalidOperationException || ex is UriFormatException || ex is Win32Exception)
        {
            MessageBox.Show($"Le lien vers le site web ne correspond pas au format requis ! | {ex.Message}", "Erreur format", MessageBoxButton.OK, MessageBoxImage.Error);
            _navigationService.NavigateTo<Views.Teacher.CompaniesView>();
        }
        catch (PlatformNotSupportedException ex)
        {
            MessageBox.Show($"Le système d'exploitation ne supporte pas l'ouverture de liens web ! | {ex.Message}", "Erreur système", MessageBoxButton.OK, MessageBoxImage.Error);
            _navigationService.NavigateTo<Views.Teacher.CompaniesView>();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Une erreur s'est produite lors de l'ouverture du site web ! | {ex.Message}", "Erreur inconnue", MessageBoxButton.OK, MessageBoxImage.Error);
            _navigationService.NavigateTo<Views.Teacher.CompaniesView>();
        }
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
                                company.Address.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                (company.Email?.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ?? false) ||
                                (company.PhoneNumber?.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ?? false);
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
}
