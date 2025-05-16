using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Classe;

public partial class ModifyViewModel : BaseViewModel, INavigableWithParameter
{
    [ObservableProperty]
    private Models.Classe? _classe;

    [ObservableProperty]
    private ObservableCollection<Models.Teacher> _teachers;

    private readonly INavigationService _navigationService;

    public ModifyViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        _teachers =
        [
            new() {Id = 1, LastName = "Dupont", FirstName = "Jean", Classe = new() { Id = 1, Name = "Classe A" } },
            new() {Id = 2, LastName = "Martin", FirstName = "Marie", Classe = new() { Id = 2, Name = "Classe B" } },
            new() {Id = 3, LastName = "Durand", FirstName = "Pierre", Classe = new() { Id = 3, Name = "Classe C" } },
            new() {Id = 4, LastName = "Leroy", FirstName = "Sophie", Classe = new() { Id = 4, Name = "Classe D" } },
            new() {Id = 5, LastName = "Moreau", FirstName = "Luc", Classe = new() { Id = 5, Name = "Classe E" } },
            new() {Id = 6, LastName = "Simon", FirstName = "Claire", Classe = new() { Id = 6, Name = "Classe F" } },
            new() {Id = 7, LastName = "Michel", FirstName = "Julien", Classe = new() { Id = 7, Name = "Classe G" } },
            new() {Id = 8, LastName = "Lemoine", FirstName = "Alice", Classe = new() { Id = 8, Name = "Classe H" } },
            new() {Id = 9, LastName = "Garnier", FirstName = "Thomas", Classe = new() { Id = 9, Name = "Classe I" } },
            new() {Id = 10, LastName = "Rousseau", FirstName = "Emma", Classe = new() { Id = 10, Name = "Classe J" } },
        ];
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Models.Classe classe)
        {
            Classe = classe;
            Classe.Teacher = Teachers.FirstOrDefault(t => t.Classe?.Id == classe.Id);
        }
    }

    [RelayCommand]
    private void ModifyClasse()
    {
        MessageBox.Show($"Classe {Classe?.Name} - {Classe?.Teacher?.FullName} modifiée avec succès !", "Modification réussie", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.ClassesView>();
    }
}
