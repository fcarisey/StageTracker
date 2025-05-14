using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.ViewModels.Admin;
using StageTracker.Views;

namespace StageTracker.ViewModels.Teacher;

public partial class StudentsViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<Models.Student> _students;

    private INavigationService _navigationService;

    public StudentsViewModel(INavigationService navigationService)
    {
        Students = new ObservableCollection<Models.Student>
        {
            new() { Id = 1, Address = "6, Rue du beau lièvre", LastName = "Dupont", FirstName = "Alice", Classe = "BTS SIO1", Email = "alice.dupont@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 2, Address = "6, Rue du beau lièvre", LastName = "Martin", FirstName = "Lucas", Classe = "BTS SIO1", Email = "lucas.martin@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 3, Address = "6, Rue du beau lièvre", LastName = "Nguyen", FirstName = "Chloé", Classe = "BTS SIO2", Email = "chloe.nguyen@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 4, Address = "6, Rue du beau lièvre", LastName = "Lemoine", FirstName = "Julien", Classe = "BTS SIO2", Email = "julien.lemoine@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 5, Address = "6, Rue du beau lièvre", LastName = "Bouchard", FirstName = "Emma", Classe = "BTS SIO1", Email = "emma.bouchard@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 3, Address = "6, Rue du beau lièvre", LastName = "Nguyen", FirstName = "Chloé", Classe = "BTS SIO2", Email = "chloe.nguyen@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 4, Address = "6, Rue du beau lièvre", LastName = "Lemoine", FirstName = "Julien", Classe = "BTS SIO2", Email = "julien.lemoine@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 5, Address = "6, Rue du beau lièvre", LastName = "Bouchard", FirstName = "Emma", Classe = "BTS SIO1", Email = "emma.bouchard@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 3, Address = "6, Rue du beau lièvre", LastName = "Nguyen", FirstName = "Chloé", Classe = "BTS SIO2", Email = "chloe.nguyen@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 4, Address = "6, Rue du beau lièvre", LastName = "Lemoine", FirstName = "Julien", Classe = "BTS SIO2", Email = "julien.lemoine@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 5, Address = "6, Rue du beau lièvre", LastName = "Bouchard", FirstName = "Emma", Classe = "BTS SIO1", Email = "emma.bouchard@example.com", PhoneNumber = "00.00.00.00.00" }
        };
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void NavigateToStudentDetailsView(object student)
    {
        _navigationService.NavigateTo<Views.Teacher.Student.ShowView>(student);
    }

    [RelayCommand]
    public void NavigateToStudentEditView(object student)
    {
        _navigationService.NavigateTo<Views.Teacher.Student.ShowView>(student);
    }
}
