using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Services.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace StageTracker.ViewModels.Admin;

public partial class ClassesViewModel : BaseViewModel
{
    private ObservableCollection<Shared.ModelsEF.Classe> _classes = [];

    [ObservableProperty]
    private ICollectionView _filteredClasses = default!;

    private readonly INavigationService _navigationService;

    private readonly ClasseDataService _classeDataService;

    public ClassesViewModel(INavigationService navigationService, ClasseDataService classeDataService)
    {
        _classeDataService = classeDataService;
        _navigationService = navigationService;

        LoadClassesAsync();        
    }

    private async void LoadClassesAsync()
    {
        var classes = await _classeDataService.GetAllClassesAsync();

        _classes = new ObservableCollection<Shared.ModelsEF.Classe>(classes);
        FilteredClasses = CollectionViewSource.GetDefaultView(_classes);
    }

    [RelayCommand]
    public void OnTextChanged(string searchTerms)
    {
        if (!string.IsNullOrEmpty(searchTerms) && searchTerms.Length > 0)
        {
            searchTerms = searchTerms.Trim();
            FilteredClasses.Filter = x =>
            {
                if (x is Shared.ModelsEF.Classe classe)
                {
                    if (classe != null)
                    {
                        return classe.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) || 
                               ((classe.Teacher != null) && classe.Teacher.FullName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase));
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
    public void ModifyClasse(Shared.ModelsEF.Classe classe)
    {
        _navigationService.NavigateTo<Views.Admin.Classe.ModifyView>(classe);
    }

    [RelayCommand]
    public void DeleteClasse(Shared.ModelsEF.Classe classe)
    {
        MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer {classe.Name}", "Suppression de classe", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            _classeDataService.DeleteClasseAsync(classe);
            _classes.Remove(classe);
            FilteredClasses.Refresh();
        }
    }
}
