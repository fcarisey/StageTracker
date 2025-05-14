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

    private static int _counter;

    public CompaniesViewModel(INavigationService navigationService)
    {
        _counter++;
        Debug.WriteLine($"CompaniesViewModel instance count: {_counter}");
        _navigationService = navigationService;
        Companies = new ObservableCollection<Models.Company>
        {
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
            new Models.Company { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "Companya@exemple.com", Website = "https://www.companya.com" },
        };
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
        ProcessStartInfo psi = new ProcessStartInfo()
        {
            FileName = url,
            UseShellExecute = true
        };

        Process.Start(psi);
    }
}
