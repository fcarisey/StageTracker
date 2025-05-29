using StageTracker.Interfaces.ViewModels;
using StageTracker.ViewModels.Teacher.Student.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StageTracker.Views.Teacher.Student.Application;

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
