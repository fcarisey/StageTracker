using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.WPF.Interfaces.Services;
using StageTracker.WPF.Services.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;

namespace StageTracker.WPF.ViewModels.Admin;

public partial class StudentsViewModel : BaseViewModel
{
    private ObservableCollection<Shared.ModelsEF.Student> _students = [];

    [ObservableProperty]
    private ICollectionView _filteredStudents = default!;

    private readonly INavigationService _navigationService;

    private readonly StudentDataService _studentDataService;

    public StudentsViewModel(INavigationService navigationService, StudentDataService studentDataService)
    {
        _studentDataService = studentDataService;
        _navigationService = navigationService;

        LoadStudentsAsync();
    }

    public async void LoadStudentsAsync()
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
            _students = new ObservableCollection<Shared.ModelsEF.Student>(students);

            FilteredStudents = CollectionViewSource.GetDefaultView(_students);
            FilteredStudents.Refresh();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error loading students: " + ex.Message);
        }
        
    }

    [RelayCommand]
    public void OnTextChanged(string searchTerms)
    {
        if (!string.IsNullOrEmpty(searchTerms) && searchTerms.Length > 0)
        {
            searchTerms = searchTerms.Trim();
            FilteredStudents.Filter = x =>
            {
                if (x is Shared.ModelsEF.Student student)
                {
                    if (student != null)
                    {
                        return student.FullName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                               ((student.Classe is not null) && student.Classe.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase));
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

    [RelayCommand]
    public void AddStudent()
    {
        _navigationService.NavigateTo<Views.Admin.Student.AddView>();
    }

    [RelayCommand]
    public void ModifyStudent(Shared.ModelsEF.Student student)
    {
        _navigationService.NavigateTo<Views.Admin.Student.ModifyView>(student);
    }

    [RelayCommand]
    public void DeleteStudent(Shared.ModelsEF.Student student)
    {
        MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer {student.FullName}", "Suppression d'étudiant", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            _studentDataService.DeleteStudentAsync(student);
            _students.Remove(student);

            FilteredStudents.Refresh();
        }
    }
}
