using System.Windows.Controls;

namespace StageTracker.Interfaces.Services;

public interface INavigationService
{
    public void NavigateTo<TView>() where TView : UserControl;
    public void NavigateTo<TView>(object parameter) where TView : UserControl;
}
