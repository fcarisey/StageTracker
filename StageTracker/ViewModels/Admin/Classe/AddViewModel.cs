using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.WPF.Interfaces.Services;
using StageTracker.WPF.Services.Data;
using System.Collections.ObjectModel;
using System.Windows;

namespace StageTracker.WPF.ViewModels.Admin.Classe;

public partial class AddViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private Shared.ModelsEF.Teacher? _teacher;

    [ObservableProperty]
    private ObservableCollection<Shared.ModelsEF.Teacher> _teachers = [];

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
        Teachers = new ObservableCollection<Shared.ModelsEF.Teacher>(teachers);
    }

    [RelayCommand]
    private void AddClasse()
    {
        _classeDataService.AddClasseAsync(new Shared.ModelsEF.Classe
        {
            Name = Name,
            Teacher = Teacher
        });

        MessageBox.Show($"Classe créé avec succès ! {Name} - {Teacher?.FullName}", "Création de classe", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.ClassesView>();
    }
}
