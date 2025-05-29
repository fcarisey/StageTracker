using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Services.Data;
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

    private readonly ClasseDataService _classeDataService;

    private readonly TeacherDataService _teacherDataService;

    public AddViewModel(INavigationService navigationService, ClasseDataService classeDataService, TeacherDataService teacherDataService)
    {
        _navigationService = navigationService;
        _classeDataService = classeDataService;
        _teacherDataService = teacherDataService;

        LoadTeachersAsync();
    }

    private async void LoadTeachersAsync()
    {
        var teachers = await _teacherDataService.GetAllTeachersAsync();
        Teachers = new ObservableCollection<Models.Teacher>(teachers);
    }

    [RelayCommand]
    private void AddClasse()
    {
        _classeDataService.AddClasseAsync(new Models.Classe
        {
            Name = Name,
            Teacher = Teacher
        });

        MessageBox.Show($"Classe créé avec succès ! {Name} - {Teacher?.FullName}", "Création de classe", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.ClassesView>();
    }
}
