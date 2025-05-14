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
            new() { Id = 1, Address = "6, Rue du beau lièvre", LastName = "Dupont", FirstName = "Alice", Classe = "BTS SIO1", Mail = "alice.dupont@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 2, Address = "6, Rue du beau lièvre", LastName = "Martin", FirstName = "Lucas", Classe = "BTS SIO1", Mail = "lucas.martin@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 3, Address = "6, Rue du beau lièvre", LastName = "Nguyen", FirstName = "Chloé", Classe = "BTS SIO2", Mail = "chloe.nguyen@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 4, Address = "6, Rue du beau lièvre", LastName = "Lemoine", FirstName = "Julien", Classe = "BTS SIO2", Mail = "julien.lemoine@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 5, Address = "6, Rue du beau lièvre", LastName = "Bouchard", FirstName = "Emma", Classe = "BTS SIO1", Mail = "emma.bouchard@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 3, Address = "6, Rue du beau lièvre", LastName = "Nguyen", FirstName = "Chloé", Classe = "BTS SIO2", Mail = "chloe.nguyen@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 4, Address = "6, Rue du beau lièvre", LastName = "Lemoine", FirstName = "Julien", Classe = "BTS SIO2", Mail = "julien.lemoine@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 5, Address = "6, Rue du beau lièvre", LastName = "Bouchard", FirstName = "Emma", Classe = "BTS SIO1", Mail = "emma.bouchard@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 3, Address = "6, Rue du beau lièvre", LastName = "Nguyen", FirstName = "Chloé", Classe = "BTS SIO2", Mail = "chloe.nguyen@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 4, Address = "6, Rue du beau lièvre", LastName = "Lemoine", FirstName = "Julien", Classe = "BTS SIO2", Mail = "julien.lemoine@example.com", Phone = "00.00.00.00.00" },
            new() { Id = 5, Address = "6, Rue du beau lièvre", LastName = "Bouchard", FirstName = "Emma", Classe = "BTS SIO1", Mail = "emma.bouchard@example.com", Phone = "00.00.00.00.00" }
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
