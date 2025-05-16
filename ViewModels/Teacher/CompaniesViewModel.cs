using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace StageTracker.ViewModels.Teacher;

public partial class CompaniesViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    private readonly ObservableCollection<Models.Company> _companies;

    [ObservableProperty]
    private ICollectionView _filteredCompanies;

    public CompaniesViewModel(INavigationService navigationService)
    {
        Models.Student st1 = new() { Id = 1, Address = "6, Rue du beau lièvre", LastName = "Dupont", FirstName = "Alice", Classe = "BTS SIO1", Email = "alice.dupont@example.com", PhoneNumber = "00.00.00.00.00" };
        Models.Company c1 = new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "companya@gmail.com", Website = "https://www.companya.com" };
        Models.Intership i1 = new() { Id = 1, Title = "Dévloppeur C#", Description = "Application interne en C#", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(14), Location = "12, Rue du Val d'amour, 39100 Dole", Student = st1, Company = c1 };

        st1.Internships.Add(i1);
        c1.Internships.Add(i1);

        _companies =
        [
            c1,
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company B", Address = "123 Main St", PhoneNumber = "123-456-7891", Email = "Companyb@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company C", Address = "123 Main St", PhoneNumber = "123-456-7892", Email = "Companyc@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company D", Address = "123 Main St", PhoneNumber = "123-456-7893", Email = "Companyd@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company E", Address = "123 Main St", PhoneNumber = "123-456-7894", Email = "Companye@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company F", Address = "123 Main St", PhoneNumber = "123-456-7895", Email = "Companyf@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company G", Address = "123 Main St", PhoneNumber = "123-456-7896", Email = "Companyg@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company H", Address = "123 Main St", PhoneNumber = "123-456-7897", Email = "Companyh@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company I", Address = "123 Main St", PhoneNumber = "123-456-7898", Email = "Companyi@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company J", Address = "123 Main St", PhoneNumber = "123-456-7899", Email = "Companyj@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company K", Address = "123 Main St", PhoneNumber = "123-456-7900", Email = "Companyk@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company L", Address = "123 Main St", PhoneNumber = "123-456-7901", Email = "Companyl@exemple.com", Website = "https://www.companya.com" },
        ];

        _navigationService = navigationService;
        _filteredCompanies = CollectionViewSource.GetDefaultView(_companies);
    }

    [RelayCommand]
    public void NavigateToCompanyShowView(object company)
    {
        if (company == null)
            throw new ArgumentNullException(nameof(company), "Company cannot be null.");

        _navigationService.NavigateTo<Views.Teacher.Company.ShowView>(company);
    }

    [RelayCommand]
    public static void ShowCompanyWebsite(string url)
    {
        ProcessStartInfo psi = new ()
        {
            FileName = url,
            UseShellExecute = true
        };

        Process.Start(psi);
    }


    [RelayCommand]
    public void OnTextChanged(string searchTerms)
    {
        if (!string.IsNullOrEmpty(searchTerms) && searchTerms.Length > 0)
        {
            searchTerms = searchTerms.Trim();
            FilteredCompanies.Filter = x =>
            {
                if (x is Models.Company company)
                {
                    if (company != null)
                    {
                        return company.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                company.Address.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                company.Email.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                company.PhoneNumber.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                company.PhoneNumber.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase);
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
