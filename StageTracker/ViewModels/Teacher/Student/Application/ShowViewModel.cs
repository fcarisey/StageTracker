using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using System.Windows;

namespace StageTracker.ViewModels.Teacher.Student.Application;

public partial class ShowViewModel : BaseViewModel, INavigableWithParameter
{
    [ObservableProperty]
    private Models.Application? _application;

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Models.Application application)
            Application = application;
        else
            throw new ArgumentException("Invalid parameter type", nameof(parameter));
    }

    [RelayCommand]
    public void AddRemark()
    {
        MessageBox.Show("Ajout d'une remarque pour " + Application?.Student.FullName);  
    }

    [RelayCommand]
    public void DownloadCV()
    {
        MessageBox.Show("Téléchargement du CV de " + Application?.Student.FullName);
    }

    [RelayCommand]
    public void DownloadLM()
    {
        MessageBox.Show("Téléchargement de la lettre de motivation de " + Application?.Student.FullName);
    }
}