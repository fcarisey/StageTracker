using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Models;
using StageTracker.Services.Data;
using StageTracker.ViewModels.Admin;
using StageTracker.Views;
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

namespace StageTracker.ViewModels.Teacher;

public partial class StudentsViewModel : BaseViewModel
{
    private ObservableCollection<Models.Student> _students = [];

    [ObservableProperty]
    private ICollectionView _filteredStudents;

    private readonly INavigationService _navigationService;

    private readonly StudentDataService _studentDataService;

    public StudentsViewModel(INavigationService navigationService, StudentDataService studentDataService)
    {
        _studentDataService = studentDataService;
        _filteredStudents = CollectionViewSource.GetDefaultView(_students);

        LoadStudentsAsync();

        _navigationService = navigationService;
    }

    private async void LoadStudentsAsync()
    {
        try
        {
            var students = await _studentDataService.GetAllStudentsAsync();

            if (students == null || students.Count == 0)
            {
                MessageBox.Show("No students found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            _students.Clear();
            _students = new ObservableCollection<Models.Student>(students);
            FilteredStudents = CollectionViewSource.GetDefaultView(_students);
            FilteredStudents.Refresh();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error loading students: " + ex.Message);
        }
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
                                ((student.Classe is not null) && student.Classe.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase)) ||
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
