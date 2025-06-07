using StageTracker.Interfaces.ViewModels;
using StageTracker.ViewModels.Teacher.Student;
using System.Windows.Controls;

namespace StageTracker.Views.Teacher.Student;

/// <summary>
/// Logique d'interaction pour Show.xaml
/// </summary>
public partial class ShowView : UserControl, INavigableWithParameter
{
    public ShowView(ShowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }

    public void OnNavigatedTo(object parameter)
    {
        if (DataContext is INavigableWithParameter vm)
            vm.OnNavigatedTo(parameter);
    }
}
