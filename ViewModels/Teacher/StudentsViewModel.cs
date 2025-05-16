using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.ViewModels.Admin;
using StageTracker.Views;

namespace StageTracker.ViewModels.Teacher;

public partial class StudentsViewModel : BaseViewModel
{
    private ObservableCollection<Models.Student> _students;

    [ObservableProperty]
    private ICollectionView _filteredStudents;

    private readonly INavigationService _navigationService;

    public StudentsViewModel(INavigationService navigationService)
    {
        Models.Student st1 = new() { Id = 1, Address = "6, Rue du beau lièvre", LastName = "Dupont", FirstName = "Alice", Classe = "BTS SIO1", Email = "alice.dupont@example.com", PhoneNumber = "00.00.00.00.00" };
        Models.Company c1 = new() { Id = 1, Name = "Company A", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "companya@gmail.com", Website = "https://www.companya.com" };
        Models.Intership i1 = new() { Id = 1, Title = "Dévloppeur C#", Description = "Application interne en C#", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(14), Location = "12, Rue du Val d'amour, 39100 Dole", Student = st1, Company = c1};
        
        st1.Internships.Add(i1);

        Models.Application a1 = new() { Id = 1, Student = st1, Internship = i1, Status = "Refusé"};

        st1.Applications.Add(a1);

        _students =
        [
            
            st1,
            new() { Id = 2, Address = "6, Rue du beau lièvre", LastName = "Martin", FirstName = "Lucas", Classe = "BTS SIO1", Email = "lucas.martin@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 3, Address = "7, Rue du beau lièvre", LastName = "Nguyen", FirstName = "Chloé", Classe = "BTS SIO1", Email = "chloe.nguyen@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 4, Address = "8, Rue du beau lièvre", LastName = "Lemoine", FirstName = "Henri", Classe = "STMG", Email = "henri.lemoine@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 5, Address = "9, Rue du beau lièvre", LastName = "Bouchard", FirstName = "Emma", Classe = "STMG", Email = "emma.bouchard@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 3, Address = "10, Rue du beau lièvre", LastName = "Nguyen", FirstName = "Pare-brise", Classe = "BTS SIO2", Email = "pare-brise.nguyen@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 4, Address = "11, Rue du beau lièvre", LastName = "Lemoine", FirstName = "Julien", Classe = "BTS SIO2", Email = "julien.lemoine@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 5, Address = "12, Rue du beau lièvre", LastName = "Bouchard", FirstName = "Antoine", Classe = "LICENCE LID", Email = "antoine.bouchard@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 3, Address = "13, Rue du beau lièvre", LastName = "Nguyen", FirstName = "Sophie", Classe = "BTS SIO2", Email = "sophie.nguyen@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 4, Address = "14, Rue du beau lièvre", LastName = "Lemoine", FirstName = "Sylvain", Classe = "LICENCE LID", Email = "sylvain.lemoine@example.com", PhoneNumber = "00.00.00.00.00" },
            new() { Id = 5, Address = "15, Rue du beau lièvre", LastName = "Bouchard", FirstName = "Mark", Classe = "BTS SIO1", Email = "mark.bouchard@example.com", PhoneNumber = "00.00.00.00.00" }
        ];

        _navigationService = navigationService;
        _filteredStudents = CollectionViewSource.GetDefaultView(_students);
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

    [RelayCommand]
    public void OnTextChanged(string searchTerms)
    {
        if (!string.IsNullOrEmpty(searchTerms) && searchTerms.Length > 0)
        {
            searchTerms = searchTerms.Trim();
            FilteredStudents.Filter = x =>
            {
                if (x is Models.Student student)
                {
                    if (student != null)
                    {
                        return student.FirstName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                student.LastName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                student.PhoneNumber.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                student.Classe.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                student.Email.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase);
                    }
                }

                return false;
            };

            FilteredStudents.Refresh();
        }
        else
        {
            FilteredStudents.Filter = null;
            FilteredStudents.Refresh();
        }
    }
}
