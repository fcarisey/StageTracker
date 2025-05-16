using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Company;

public partial class ModifyViewModel : BaseViewModel, INavigableWithParameter
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private Models.Company? _company;

    public ModifyViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
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
        // Créer un nouvel enseignant dans la base de données
        MessageBox.Show($"Company modifié avec succès ! {Company?.Name} - {Company?.Email} - {Company?.Website}", "Création d'entreprise", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.CompaniesView>();
    }
}
