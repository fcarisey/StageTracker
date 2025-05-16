using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Teacher;

public partial class AddViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private string _firstName = string.Empty;

    [ObservableProperty]
    private string _lastName = string.Empty;

    [ObservableProperty]
    private Models.Classe? _classe;

    [ObservableProperty]
    private ObservableCollection<Models.Classe> _classes = [];

    public AddViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        _classes = 
        [
            new () { Id = 1, Name = "Classe A" },
            new () { Id = 2, Name = "Classe B" },
            new () { Id = 3, Name = "Classe C" },
            new () { Id = 4, Name = "Classe D" },
            new () { Id = 5, Name = "Classe E" },
            new () { Id = 6, Name = "Classe F" },
            new () { Id = 7, Name = "Classe G" },
            new () { Id = 8, Name = "Classe H" },
            new () { Id = 9, Name = "Classe I" },
            new () { Id = 10, Name = "Classe J" },
        ];
    }

    [RelayCommand]
    private void AddTeacher()
    {
        // Créer un nouvel enseignant dans la base de données
        MessageBox.Show($"Enseignant créé avec succès ! {FirstName} {LastName} - {Classe.Name}", "Création d'enseignant", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.TeachersView>();
    }
}
