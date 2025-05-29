using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using StageTracker.Services.Data;
using System.Collections.ObjectModel;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Teacher;

public partial class ModifyViewModel : BaseViewModel, INavigableWithParameter
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private Models.Teacher _teacher = default!;

    [ObservableProperty]
    private ObservableCollection<Models.Classe> _classes = [];

    private readonly ClasseDataService _classeDataService;

    private readonly TeacherDataService _teacherDataService;

    public ModifyViewModel(INavigationService navigationService, ClasseDataService classeDataService, TeacherDataService teacherDataService)
    {
        _navigationService = navigationService;
        _classeDataService = classeDataService;
        _teacherDataService = teacherDataService;

        LoadClassesAsync();
    }

    private async void LoadClassesAsync()
    {
        var classes = await _classeDataService.GetAllClassesAsync();
        Classes = new ObservableCollection<Models.Classe>(classes);
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Models.Teacher teacher)
        {
            Teacher = teacher;
        }
    }

    [RelayCommand]
    private void ModifyTeacher()
    {
        _teacherDataService.UpdateTeacherAsync(Teacher);
        MessageBox.Show($"Enseignant modifié avec succès ! {Teacher.FirstName} {Teacher.LastName} - {Teacher.Classe?.Name}", "Création d'enseignant", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.TeachersView>();
    }
}
