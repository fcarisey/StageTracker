using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using StageTracker.ViewModels;

namespace StageTracker.Services;

public class NavigationService(IServiceProvider provider) : INavigationService
{
    private readonly IServiceProvider _provider = provider;

    private static MainWindow MainWindow => (MainWindow)Application.Current.MainWindow;

    public void NavigateTo<TView>() where TView : UserControl
    {
        var navigateTo = _provider.GetRequiredService<TView>();
        ((MainWindowViewModel)MainWindow.DataContext).CurrentPage = navigateTo;
    }

    public void NavigateTo<TView>(object parameter) where TView : UserControl
    {
        var navigateTo = _provider.GetRequiredService<TView>();

        if (navigateTo is INavigableWithParameter navigable)
        {
            navigable.OnNavigatedTo(parameter);
            ((MainWindowViewModel)MainWindow.DataContext).CurrentPage = navigateTo;
        }
        else
        {
            throw new InvalidOperationException($"Type {typeof(TView).Name} does not implement INavigableWithParameter.");
        }

    }
}
