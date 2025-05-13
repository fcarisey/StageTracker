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
using StageTracker.ViewModels.Admin;

namespace StageTracker.ViewModels.Teacher;

public partial class StudentsViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<Models.Student> _students;

    public StudentsViewModel()
    {
        Students = new ObservableCollection<Models.Student>
        {
            new() { Id = 1, Nom = "Dupont", Prenom = "Alice", Classe = "BTS SIO1", Email = "alice.dupont@example.com" },
            new() { Id = 2, Nom = "Martin", Prenom = "Lucas", Classe = "BTS SIO1", Email = "lucas.martin@example.com" },
            new() { Id = 3, Nom = "Nguyen", Prenom = "Chloé", Classe = "BTS SIO2", Email = "chloe.nguyen@example.com" },
            new() { Id = 4, Nom = "Lemoine", Prenom = "Julien", Classe = "BTS SIO2", Email = "julien.lemoine@example.com" },
            new() { Id = 5, Nom = "Bouchard", Prenom = "Emma", Classe = "BTS SIO1", Email = "emma.bouchard@example.com" }
        };
    }

    [RelayCommand]
    public void NavigateToStudentDetailsView(object student)
    {
        MessageBox.Show($"{student.GetType()}");
        MessageBox.Show($"Navigating to details for {((Models.Student)student).Prenom} {((Models.Student)student).Nom}");
    }

    [RelayCommand]
    public void NavigateToStudentEditView(object student)
    {
        MessageBox.Show($"Navigating to edit for {((Models.Student)student).Prenom} {((Models.Student)student).Nom}");
    }
}
