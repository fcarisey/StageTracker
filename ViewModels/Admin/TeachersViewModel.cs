using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace StageTracker.ViewModels.Admin;

public partial class TeachersViewModel : BaseViewModel
{
    private readonly ObservableCollection<Models.Teacher> _teachers;

    [ObservableProperty]
    private ICollectionView _filteredTeachers;

    private readonly INavigationService _navigationService;

    public TeachersViewModel(INavigationService navigationService)
    {

        _teachers = 
        [
            new() {Id = 1, LastName = "Dupont", FirstName = "Jean", Classe = new() { Id = 1, Name = "Classe A" } },
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
        _filteredTeachers = CollectionViewSource.GetDefaultView(_teachers);
    }

    [RelayCommand]
    public void OnTextChanged(string searchTerms)
    {
        if (!string.IsNullOrEmpty(searchTerms) && searchTerms.Length > 0)
        {
            FilteredTeachers.Filter = x =>
            {
                if (x is Models.Teacher teacher)
                {
                    if (teacher != null)
                    {
                        return teacher.FullName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                               ((teacher.Classe is not null) ? teacher.Classe.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) : false);
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
    public void ModifyTeacher(Models.Teacher teacher)
    {
        _navigationService.NavigateTo<Views.Admin.Teacher.ModifyView>(teacher);
    }

    [RelayCommand]
    public void DeleteTeacher(Models.Teacher teacher)
    {
        MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer {teacher.FullName}", "Suppression d'enseignant", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        
        if (result == MessageBoxResult.Yes)
        {
            // Supression de la bdd
            _teachers.Remove(teacher);
            FilteredTeachers.Refresh();
        }
    }
}
