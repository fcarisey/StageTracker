using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.ViewModels;
using System.Windows;

namespace StageTracker.ViewModels.Teacher.Company;

public partial class ShowViewModel : BaseViewModel, INavigableWithParameter
{
    [ObservableProperty]
    private Shared.ModelsEF.Company? _company;

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Shared.ModelsEF.Company company)
        {
            Company = company;
        }
        else
        {
            throw new ArgumentException("Parameter must be of type Company", nameof(parameter));
        }
    }

    [RelayCommand]
    public void ShowReport()
    {
        MessageBox.Show($"Show report for {Company?.Name}");
    }
}
