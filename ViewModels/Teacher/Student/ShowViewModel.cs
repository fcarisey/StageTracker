using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;

namespace StageTracker.ViewModels.Teacher.Student;

public partial class ShowViewModel : BaseViewModel, INavigableWithParameter
{
    [ObservableProperty]
    private Models.Student? _student;

    private readonly INavigationService _navigationService;

    public ShowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Models.Student student)
            Student = student;
        else
            _navigationService.NavigateTo<Views.Teacher.StudentsView>();
    }

    [RelayCommand]
    public void DownloadCV()
    {
        MessageBox.Show("Téléchargement du CV de " + Student?.FullName);
    }

    [RelayCommand]
    public void AddRemark()
    {
        MessageBox.Show("Ajout d'une remarque pour " + Student?.FullName);
    }
}
