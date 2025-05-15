using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StageTracker.ViewModels.Teacher;

public partial class CompaniesViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ObservableCollection<Models.Company> _companies;

    public CompaniesViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        Models.Student st1 = new() { Id = 1, Address = "6, Rue du beau lièvre", LastName = "Dupont", FirstName = "Alice", Classe = "BTS SIO1", Email = "alice.dupont@example.com", PhoneNumber = "00.00.00.00.00" };
        Models.Company c1 = new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "companya@gmail.com", Website = "https://www.companya.com" };
        Models.Intership i1 = new() { Id = 1, Title = "Dévloppeur C#", Description = "Application interne en C#", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(14), Location = "12, Rue du Val d'amour, 39100 Dole", Student = st1, Company = c1 };

        st1.Internships.Add(i1);
        c1.Internships.Add(i1);

        Companies =
        [
            c1,
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
        ];
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
}
