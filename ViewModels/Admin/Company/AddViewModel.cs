using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
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

    public AddViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        _companies =
        [
            new() {Id = 1, Name = "Google", Address = "1600 Amphitheatre Parkway, Mountain View, CA 94043", PhoneNumber = "+1 650-253-0000", Email = "google@gmail.com", Website = "https://www.google.com"},
            new() {Id = 2, Name = "Microsoft", Address = "1 Microsoft Way, Redmond, WA 98052", PhoneNumber = "+1 425-882-8080", Email = "microsoft@gmail.com", Website = "https://www.microsoft.com"},
            new() {Id = 3, Name = "Apple", Address = "1 Apple Park Way, Cupertino, CA 95014", PhoneNumber = "+1 408-996-1010", Email = "apple@gmail.com", Website = "https://www.apple.com"},
            new() {Id = 4, Name = "Amazon", Address = "410 Terry Ave N, Seattle, WA 98109", PhoneNumber = "+1 206-266-1000", Email = "amazon@gmail.com", Website = "https://www.amazon.com"},
            new() {Id = 5, Name = "Facebook", Address = "1 Hacker Way, Menlo Park, CA 94025", PhoneNumber = "+1 650-543-4800", Email = "facebook@gmail.com", Website = "https://www.facebook.com"},
            new() {Id = 6, Name = "Netflix", Address = "100 Winchester Circle, Los Gatos, CA 95032", PhoneNumber = "+1 408-540-3700", Email = "netflix@gmail.com", Website = "https://www.netflix.com"},
            new() {Id = 7, Name = "Tesla", Address = "3500 Deer Creek Road, Palo Alto, CA 94304", PhoneNumber = "+1 650-681-5000", Email = "tesla@gmail.com", Website = "https://www.tesla.com"},
            new() {Id = 8, Name = "SpaceX", Address = "1 Rocket Road, Hawthorne, CA 90250", PhoneNumber = "+1 310-363-6000", Email = "spacex@gmail.com", Website = "https://www.spacex.com"},
            new() {Id = 9, Name = "IBM", Address = "1 New Orchard Road, Armonk, NY 10504", PhoneNumber = "+1 914-499-1900", Email = "ibm@gmail.com", Website = "https://www.ibm.com"},
            new() {Id = 10, Name = "Intel", Address = "2200 Mission College Blvd, Santa Clara, CA 95054", PhoneNumber = "+1 408-765-8080", Email = "intel@gmail.com", Website = "https://www.intel.com"},
        ];
    }

    [RelayCommand]
    private void AddCompany()
    {
        // Créer un nouvel enseignant dans la base de données
        MessageBox.Show($"Companie créé avec succès ! {Name} - {Email} - {Address}", "Création d'une campanie", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.CompaniesView>();
    }
}
