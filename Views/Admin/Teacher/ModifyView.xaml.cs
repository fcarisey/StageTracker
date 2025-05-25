using StageTracker.Interfaces.ViewModels;
using StageTracker.ViewModels.Admin.Teacher;
using System.Windows.Controls;

namespace StageTracker.Views.Admin.Teacher;

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
}
