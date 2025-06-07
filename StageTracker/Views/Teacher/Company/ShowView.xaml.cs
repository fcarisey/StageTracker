using StageTracker.Interfaces.ViewModels;
using StageTracker.ViewModels.Teacher.Company;
using System.Windows.Controls;

namespace StageTracker.Views.Teacher.Company;

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
        if (parameter is Shared.ModelsEF.Company company)
        {
            ((ShowViewModel)DataContext).OnNavigatedTo(company);
        }
        else
        {
            throw new ArgumentException("Parameter must be of type Models.Company", nameof(parameter));
        }
    }
}
