using StageTracker.WPF.Interfaces.ViewModels;
using StageTracker.WPF.ViewModels.Admin.Student;
using System.Windows.Controls;

namespace StageTracker.WPF.Views.Admin.Student;

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
        if (parameter is Shared.ModelsEF.Student student)
            ((ModifyViewModel)DataContext).OnNavigatedTo(student);
        else
            throw new ArgumentException("Parameter must be a Student", nameof(parameter));
    }
}
