using StageTracker.WPF.Interfaces.ViewModels;
using StageTracker.WPF.ViewModels.Admin.Classe;
using System.Windows.Controls;

namespace StageTracker.WPF.Views.Admin.Classe;

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
