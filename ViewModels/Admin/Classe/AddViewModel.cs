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

namespace StageTracker.ViewModels.Admin.Classe;

public partial class AddViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private Models.Teacher? _teacher;

    [ObservableProperty]
    private ObservableCollection<Models.Teacher> _teachers = [];

    public AddViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        _teachers =
        [
            new() {Id = 1, LastName = "Dupont", FirstName = "Jean"},
            new() {Id = 2, LastName = "Martin", FirstName = "Marie"},
            new() {Id = 3, LastName = "Durand", FirstName = "Pierre"},
            new() {Id = 4, LastName = "Leroy", FirstName = "Sophie"},
            new() {Id = 5, LastName = "Moreau", FirstName = "Luc"},
            new() {Id = 6, LastName = "Simon", FirstName = "Claire"},
            new() {Id = 7, LastName = "Michel", FirstName = "Julien"},
            new() {Id = 8, LastName = "Lemoine", FirstName = "Alice"},
            new() {Id = 9, LastName = "Garnier", FirstName = "Thomas"},
            new() {Id = 10, LastName = "Rousseau", FirstName = "Emma"},
        ];
    }

    [RelayCommand]
    private void AddClasse()
    {
        // Créer un nouvel enseignant dans la base de données
        MessageBox.Show($"Classe créé avec succès ! {Name} - {Teacher?.FullName}", "Création de classe", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.ClassesView>();
    }
}
