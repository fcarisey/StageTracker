using StageTracker.ViewModels.Admin.Student;
using System.Windows.Controls;

namespace StageTracker.Views.Admin.Student;

/// <summary>
/// Logique d'interaction pour Add.xaml
/// </summary>
public partial class AddView : UserControl
{
    public AddView(AddViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
