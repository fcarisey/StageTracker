using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace StageTracker.ViewModels.Admin;

public partial class StudentsViewModel : BaseViewModel
{
    private readonly ObservableCollection<Models.Student> _students;

    [ObservableProperty]
    private ICollectionView _filteredStudents;

    private readonly INavigationService _navigationService;

    public StudentsViewModel(INavigationService navigationService)
    {

        _students =
        [
            new() {Id = 1, LastName = "Dupont", FirstName = "Jean", Classe = new() { Id = 1, Name = "Classe A" }, Address = "6, Rue du beau levirer, 3170 Ounans", PhoneNumber = "00000000", Email = "jdupont@gmail.com" },
            new() {Id = 2, LastName = "Martin", FirstName = "Marie", Classe = new() { Id = 2, Name = "Classe B" } },
            new() {Id = 3, LastName = "Durand", FirstName = "Pierre", Classe = new() { Id = 3, Name = "Classe C" } },
            new() {Id = 4, LastName = "Leroy", FirstName = "Sophie", Classe = new() { Id = 4, Name = "Classe D" } },
            new() {Id = 5, LastName = "Moreau", FirstName = "Luc", Classe = new() { Id = 5, Name = "Classe E" } },
            new() {Id = 6, LastName = "Simon", FirstName = "Claire", Classe = new() { Id = 6, Name = "Classe F" } },
            new() {Id = 7, LastName = "Michel", FirstName = "Julien", Classe = new() { Id = 7, Name = "Classe G" } },
            new() {Id = 8, LastName = "Lemoine", FirstName = "Alice", Classe = new() { Id = 8, Name = "Classe H" } },
            new() {Id = 9, LastName = "Garnier", FirstName = "Thomas", Classe = new() { Id = 9, Name = "Classe I" } },
            new() {Id = 10, LastName = "Rousseau", FirstName = "Emma", Classe = new() { Id = 10, Name = "Classe J" } },
        ];

        _navigationService = navigationService;
        _filteredStudents = CollectionViewSource.GetDefaultView(_students);
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
    public void ModifyStudent(Models.Student student)
    {
        _navigationService.NavigateTo<Views.Admin.Student.ModifyView>(student);
    }

    [RelayCommand]
    public void DeleteStudent(Models.Student student)
    {
        MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer {student.FullName}", "Suppression d'étudiant", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            // Supression de la bdd
            _students.Remove(student);
            FilteredStudents.Refresh();
        }
    }
}
