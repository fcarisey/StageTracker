using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using StageTracker.Services.Data;
using System.Collections.ObjectModel;
using System.Windows;

namespace StageTracker.ViewModels.Admin.Classe;

public partial class ModifyViewModel : BaseViewModel, INavigableWithParameter
{
    [ObservableProperty]
    private Shared.ModelsEF.Classe? _classe;

    [ObservableProperty]
    private ObservableCollection<Shared.ModelsEF.Teacher> _teachers = default!;

    private readonly INavigationService _navigationService;

    private readonly ClasseDataService _classeDataService;
    private readonly TeacherDataService _teacherDataService;

    public ModifyViewModel(INavigationService navigationService, ClasseDataService classeDataService, TeacherDataService teacherDataService)
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

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Shared.ModelsEF.Classe classe)
        {
            Classe = classe;
        }
    }

    [RelayCommand]
    private void ModifyClasse()
    {
        if (Classe != null)
            _classeDataService.UpdateClasseAsync(Classe);

        MessageBox.Show($"Classe {Classe?.Name} - {Classe?.Teacher?.FullName} modifiée avec succès !", "Modification réussie", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.ClassesView>();
    }
}
