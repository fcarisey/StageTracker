using StageTracker.Interfaces.ViewModels;
using StageTracker.ViewModels.Admin.Classe;
using System.Windows.Controls;

namespace StageTracker.Views.Admin.Classe;

/// <summary>
/// Logique d'interaction pour Modify.xaml
/// </summary>
public partial class ModifyView : UserControl, INavigableWithParameter
{
    public ModifyView(ModifyViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }

    public void OnNavigatedTo(object parameter)
    {
        ((ModifyViewModel)DataContext).OnNavigatedTo(parameter);
    }
}
