using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using StageTracker.Services.Data;
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
    private ObservableCollection<Models.Classe> _classes = default!;

    private readonly TeacherDataService _teacherDataService;

    private readonly ClasseDataService _classeDataService;

    public AddViewModel(INavigationService navigationService, TeacherDataService teacherDataService, ClasseDataService classeDataService)
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

    [RelayCommand]
    private void AddTeacher()
    {
        _teacherDataService.AddTeacherAsync(new Models.Teacher()
        {
            FirstName = FirstName,
            LastName = LastName,
            Classe = Classe,
        });

        MessageBox.Show($"Enseignant créé avec succès ! {FirstName} {LastName} - {Classe?.Name}", "Création d'enseignant", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.TeachersView>();
    }
}
