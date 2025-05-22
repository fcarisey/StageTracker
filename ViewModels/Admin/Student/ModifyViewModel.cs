using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Student;

public partial class ModifyViewModel : BaseViewModel, INavigableWithParameter
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private Models.Student? _student;

    [ObservableProperty]
    private ObservableCollection<Models.Classe> _classes = [];

    public ModifyViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        _classes =
        [
            new() { Id = 1, Name = "Classe A" },
            new() { Id = 2, Name = "Classe B" },
            new() { Id = 3, Name = "Classe C" },
            new() { Id = 4, Name = "Classe D" },
            new() { Id = 5, Name = "Classe E" },
            new() { Id = 6, Name = "Classe F" },
            new() { Id = 7, Name = "Classe G" },
            new() { Id = 8, Name = "Classe H" },
            new() { Id = 9, Name = "Classe I" },
            new() { Id = 10, Name = "Classe J" }
        ];
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Models.Student student)
        {
            Student = student;
            Student.Classe = Classes.FirstOrDefault(c => c.Id == student.Classe?.Id);
        }
    }

    [RelayCommand]
    private void ModifyStudent()
    {
        // Créer un nouvel enseignant dans la base de données
        MessageBox.Show($"Etudiant modifié avec succès ! {Student?.FullName} - {Student?.Email} - {Student?.Classe?.Name}", "Modification d'étudiant", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.CompaniesView>();
    }
}
