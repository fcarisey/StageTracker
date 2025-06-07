using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using StageTracker.Services.Data;
using System.Collections.ObjectModel;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Student;

public partial class ModifyViewModel : BaseViewModel, INavigableWithParameter
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private Shared.ModelsEF.Student? _student;

    [ObservableProperty]
    private ObservableCollection<Shared.ModelsEF.Classe> _classes = [];

    private readonly ClasseDataService _classeDataService;

    private readonly StudentDataService _studentDataService;

    public ModifyViewModel(INavigationService navigationService, ClasseDataService classeDataService, StudentDataService studentDataService)
    {
        _navigationService = navigationService;
        _classeDataService = classeDataService;
        _studentDataService = studentDataService;

        LoadClassesAsync();
    }

    private async void LoadClassesAsync()
    {
        var classes = await _classeDataService.GetAllClassesAsync();
        Classes = new ObservableCollection<Shared.ModelsEF.Classe>(classes);
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Shared.ModelsEF.Student student)
        {
            Student = student;
        }
    }

    [RelayCommand]
    private void ModifyStudent()
    {
        if (Student != null)
            _studentDataService.UpdateStudentAsync(Student);

        MessageBox.Show($"Etudiant modifié avec succès ! {Student?.FullName} - {Student?.Email} - {Student?.Classe?.Name}", "Modification d'étudiant", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.StudentsView>();
    }
}
