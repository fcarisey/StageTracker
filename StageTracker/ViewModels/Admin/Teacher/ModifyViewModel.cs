using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.WPF.Interfaces.Services;
using StageTracker.WPF.Interfaces.ViewModels;
using StageTracker.WPF.Services.Data;
using System.Collections.ObjectModel;
using System.Windows;

namespace StageTracker.WPF.ViewModels.Admin.Teacher;

public partial class ModifyViewModel : BaseViewModel, INavigableWithParameter
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private Shared.ModelsEF.Teacher _teacher = default!;

    [ObservableProperty]
    private ObservableCollection<Shared.ModelsEF.Classe> _classes = [];

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
        Classes = new ObservableCollection<Shared.ModelsEF.Classe>(classes);
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Shared.ModelsEF.Teacher teacher)
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
