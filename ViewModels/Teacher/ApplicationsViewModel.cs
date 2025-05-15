using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace StageTracker.ViewModels.Teacher;

public partial class ApplicationsViewModel : BaseViewModel
{

    [ObservableProperty]
    private ObservableCollection<Models.Application> _applications;

    [ObservableProperty]
    private ICollectionView _filteredApplications;

    [ObservableProperty]
    private string _searchTerms = string.Empty;

    public ApplicationsViewModel()
    {

        Models.Student s1 = new Models.Student()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "jdoe@exemple.com",
        };

        Models.Company c1 = new Models.Company()
        {
            Id = 1,
            Name = "Company 1",
            Address = "Adresse de la société 1",
            PhoneNumber = "0123456789",
            Email = "company@exemple.com",
        };

        Models.Intership i1 = new Models.Intership()
        {
            Id = 1,
            Title = "Stage 1",
            Description = "Description du stage 1",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(30),
            Company = c1,
            Student = s1,
        };

        _applications =
        [
            new() {Id = 1, Student = s1, Internship = i1, Status = "Refusé", AppliedAt = DateTime.Now.AddDays(14)},
            new() {Id = 1, Student = s1, Internship = i1, Status = "Accepté", AppliedAt = DateTime.Now.AddDays(6)},
            new() {Id = 1, Student = s1, Internship = i1, Status = "En cours", AppliedAt = DateTime.Now},
        ];

        _filteredApplications = CollectionViewSource.GetDefaultView(_applications);
    }


    [RelayCommand]
    public void OnTextChanged()
    {
        if (!string.IsNullOrEmpty(SearchTerms) && SearchTerms.Length > 0)
        {
            FilteredApplications.Filter = x =>
            {
                var application = x as Models.Application;
                if (application != null)
                {
                    return application.Student.FirstName.ToLower().Contains(SearchTerms.ToLower()) ||
                            application.Student.LastName.ToLower().Contains(SearchTerms.ToLower()) ||
                            application.Internship.Title.ToLower().Contains(SearchTerms.ToLower()) ||
                            application.Status.ToLower().Contains(SearchTerms.ToLower());
                }

                return false;
            };

            FilteredApplications.Refresh();
        }
        else
        {
            FilteredApplications.Filter = null;
            FilteredApplications.Refresh();
        }
            
    }
}
