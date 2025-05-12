using StageTracker.ViewModels.Admin.Teacher;
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

namespace StageTracker.Views.Admin.Teacher;

/// <summary>
/// Logique d'interaction pour Add.xaml
/// </summary>
public partial class AddView : Page
{
    public AddView(AddViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
