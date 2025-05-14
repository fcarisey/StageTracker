using StageTracker.Interfaces.ViewModels;
using StageTracker.ViewModels.Teacher.Company;
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

namespace StageTracker.Views.Teacher.Company;

/// <summary>
/// Logique d'interaction pour Show.xaml
/// </summary>
public partial class ShowView : Page, INavigableWithParameter
{
    public ShowView(ShowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Models.Company company)
        {
            ((ShowViewModel)DataContext).OnNavigatedTo(company);
        }
        else
        {
            throw new ArgumentException("Parameter must be of type Models.Company", nameof(parameter));
        }
    }
}
