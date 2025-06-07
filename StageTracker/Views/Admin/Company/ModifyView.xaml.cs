using StageTracker.Interfaces.ViewModels;
using StageTracker.ViewModels.Admin.Company;
using System.Windows.Controls;

namespace StageTracker.Views.Admin.Company;

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
        if (parameter is Shared.ModelsEF.Company company)
        {
            ((ViewModels.Admin.Company.ModifyViewModel)DataContext).OnNavigatedTo(company);
        }
    }
}
