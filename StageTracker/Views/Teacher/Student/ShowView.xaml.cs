using StageTracker.WPF.Interfaces.ViewModels;
using StageTracker.WPF.ViewModels.Teacher.Student;
using System.Windows.Controls;

namespace StageTracker.WPF.Views.Teacher.Student;

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
