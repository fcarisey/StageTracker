using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Services.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace StageTracker.ViewModels.Teacher;

public partial class StudentsViewModel : BaseViewModel
{
    private ObservableCollection<Shared.ModelsEF.Student> _students = [];

    [ObservableProperty]
    private ICollectionView _filteredStudents = default!;

    private readonly INavigationService _navigationService;

    private readonly StudentDataService _studentDataService;

    private readonly IUserSessionService _userSessionService;

    public StudentsViewModel(INavigationService navigationService, StudentDataService studentDataService, IUserSessionService userSessionService)
    {
        _studentDataService = studentDataService;
        _navigationService = navigationService;
        _userSessionService = userSessionService;

        LoadStudentsAsync();
    }

    private async void LoadStudentsAsync()
    {
        if (_userSessionService.ClasseId == null)
            return;

        var students = await _studentDataService.GetStudentsByClasseAsync((int)_userSessionService.ClasseId);

        if (students == null)
            return;

        _students = new ObservableCollection<Shared.ModelsEF.Student>(students);

        FilteredStudents = CollectionViewSource.GetDefaultView(_students);
        FilteredStudents.Refresh();
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
                if (x is Shared.ModelsEF.Student student)
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
