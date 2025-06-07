using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.WPF.Interfaces.Services;
using StageTracker.WPF.Services.Data;
using System.Collections.ObjectModel;
using System.Windows;

namespace StageTracker.WPF.ViewModels.Admin.Teacher;

public partial class AddViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private string _firstName = string.Empty;

    [ObservableProperty]
    private string _lastName = string.Empty;

    [ObservableProperty]
    private Shared.ModelsEF.Classe? _classe;

    [ObservableProperty]
    private ObservableCollection<Shared.ModelsEF.Classe> _classes = default!;

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
        Classes = new ObservableCollection<Shared.ModelsEF.Classe>(classes);
    }

    [RelayCommand]
    private void AddTeacher()
    {
        _teacherDataService.AddTeacherAsync(new Shared.ModelsEF.Teacher()
        {
            FirstName = FirstName,
            LastName = LastName,
            Classe = Classe,
        });

        MessageBox.Show($"Enseignant créé avec succès ! {FirstName} {LastName} - {Classe?.Name}", "Création d'enseignant", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.TeachersView>();
    }
}
