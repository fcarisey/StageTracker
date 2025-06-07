using StageTracker.ViewModels.Admin;
using System.Windows.Controls;

namespace StageTracker.Views.Admin;

/// <summary>
/// Logique d'interaction pour Students.xaml
/// </summary>
public partial class StudentsView : UserControl
{
    public StudentsView(StudentsViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
