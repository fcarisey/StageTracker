using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace StageTracker.ViewModels.Admin.Student;

public partial class AddViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private string _firstName = string.Empty;

    [ObservableProperty]
    private string _lastName = string.Empty;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _address = string.Empty;

    [ObservableProperty]
    private string _phoneNumber = string.Empty;

    [ObservableProperty]
    private Models.Classe _classe = default!;

    [ObservableProperty]
    private ObservableCollection<Models.Classe> _classes = [];

    private readonly ClasseDataService _classeDataService;

    private readonly StudentDataService _studentDataService;

    public AddViewModel(INavigationService navigationService, ClasseDataService classeDataService, StudentDataService studentDataService)
    {
        _navigationService = navigationService;
        _classeDataService = classeDataService;
        _studentDataService = studentDataService;

        LoadClassesAsync();
    }

    private async void LoadClassesAsync()
    {
        var classes = await _classeDataService.GetAllClassesAsync();

        Classes = new ObservableCollection<Models.Classe>(classes);
    }

    [RelayCommand]
    private void AddStudent()
    {
        _studentDataService.AddStudentAsync(new Models.Student
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Address = Address,
            PhoneNumber = PhoneNumber,
            ClasseId = Classe.Id
        });

        MessageBox.Show($"Etudiant créé avec succès ! {FirstName} {LastName} - {Email} - {Classe.Name}", "Création d'un étudiant", MessageBoxButton.OK, MessageBoxImage.Information);
        _navigationService.NavigateTo<Views.Admin.StudentsView>();
    }
}
