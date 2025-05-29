using StageTracker.Interfaces.ViewModels;
using StageTracker.ViewModels.Admin.Student;
using System.Windows.Controls;

namespace StageTracker.Views.Admin.Student;

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
        if (parameter is Models.Student student)
            ((ModifyViewModel)DataContext).OnNavigatedTo(student);
        else
            throw new ArgumentException("Parameter must be a Student", nameof(parameter));
    }
}
