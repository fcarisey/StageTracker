using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Services.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace StageTracker.ViewModels.Admin;

public partial class TeachersViewModel : BaseViewModel
{
    private ObservableCollection<Shared.ModelsEF.Teacher> _teachers = default!;

    [ObservableProperty]
    private ICollectionView _filteredTeachers = default!;

    private readonly INavigationService _navigationService;

    private readonly TeacherDataService _teacherDataService;

    public TeachersViewModel(INavigationService navigationService, TeacherDataService teacherDataService)
    {
        _teacherDataService = teacherDataService;
        _navigationService = navigationService;

        LoadTeachersAsync();
    }

    private async void LoadTeachersAsync()
    {
        var teachers = await _teacherDataService.GetAllTeachersAsync();

        _teachers = new ObservableCollection<Shared.ModelsEF.Teacher>(teachers);
        FilteredTeachers = CollectionViewSource.GetDefaultView(_teachers);
    }

    [RelayCommand]
    public void OnTextChanged(string searchTerms)
    {
        if (!string.IsNullOrEmpty(searchTerms) && searchTerms.Length > 0)
        {
            searchTerms = searchTerms.Trim();
            FilteredTeachers.Filter = x =>
            {
                if (x is Shared.ModelsEF.Teacher teacher)
                {
                    if (teacher != null)
                    {
                        return teacher.FullName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                               ((teacher.Classe != null) && teacher.Classe.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase));
                    }
                }

                return false;
            };

            FilteredTeachers.Refresh();
        }
        else
        {
            FilteredTeachers.Filter = null;
            FilteredTeachers.Refresh();
        }
    }

    [RelayCommand]
    public void AddTeacher()
    {
        _navigationService.NavigateTo<Views.Admin.Teacher.AddView>();
    }

    [RelayCommand]
    public void ModifyTeacher(Shared.ModelsEF.Teacher teacher)
    {
        _navigationService.NavigateTo<Views.Admin.Teacher.ModifyView>(teacher);
    }

    [RelayCommand]
    public void DeleteTeacher(Shared.ModelsEF.Teacher teacher)
    {
        MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer {teacher.FullName}", "Suppression d'enseignant", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        
        if (result == MessageBoxResult.Yes)
        {
            _teacherDataService.DeleteTeacherAsync(teacher);
            _teachers.Remove(teacher);
            FilteredTeachers.Refresh();
        }
    }
}
