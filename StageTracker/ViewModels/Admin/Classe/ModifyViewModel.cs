using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using StageTracker.Services.Data;
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
    private ObservableCollection<Models.Teacher> _teachers = default!;

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
        Teachers = new ObservableCollection<Models.Teacher>(teachers);
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Models.Classe classe)
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
