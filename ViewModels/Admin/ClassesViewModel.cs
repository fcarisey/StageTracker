using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace StageTracker.ViewModels.Admin;

public partial class ClassesViewModel : BaseViewModel
{
    private readonly ObservableCollection<Models.Classe> _classes = [];

    [ObservableProperty]
    private ICollectionView _filteredClasses;

    private readonly INavigationService _navigationService;

    public ClassesViewModel(INavigationService navigationService)
    {
        _classes =
        [
            new () { Id = 1, Name = "Classe A", Teacher = new() { Id = 1, FirstName = "Jean", LastName = "Dupont" } },
            new () { Id = 2, Name = "Classe B" },
            new () { Id = 3, Name = "Classe C" },
            new () { Id = 4, Name = "Classe D" },
            new () { Id = 5, Name = "Classe E" },
            new () { Id = 6, Name = "Classe F" },
            new () { Id = 7, Name = "Classe G" },
            new () { Id = 8, Name = "Classe H" },
            new () { Id = 9, Name = "Classe I" },
            new () { Id = 10, Name = "Classe J" },
        ];

        _filteredClasses = CollectionViewSource.GetDefaultView(_classes);
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void OnTextChanged(string searchTerms)
    {
        if (!string.IsNullOrEmpty(searchTerms) && searchTerms.Length > 0)
        {
            searchTerms = searchTerms.Trim();
            FilteredClasses.Filter = x =>
            {
                if (x is Models.Classe classe)
                {
                    if (classe != null)
                    {
                        return classe.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase);
                    }
                }

                return false;
            };

            FilteredClasses.Refresh();
        }
        else
        {
            FilteredClasses.Filter = null;
            FilteredClasses.Refresh();
        }
    }

    [RelayCommand]
    public void AddClasse()
    {
        _navigationService.NavigateTo<Views.Admin.Classe.AddView>();
    }

    [RelayCommand]
    public void ModifyClasse(Models.Classe classe)
    {
        _navigationService.NavigateTo<Views.Admin.Classe.ModifyView>(classe);
    }

    [RelayCommand]
    public void DeleteClasse(Models.Classe classe)
    {
        MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer {classe.Name}", "Suppression de classe", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            // Supression de la bdd
            _classes.Remove(classe);
            FilteredClasses.Refresh();
        }
    }
}
