using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using StageTracker.Interfaces.Services;

namespace StageTracker.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _provider;

    public NavigationService(IServiceProvider provider) => _provider = provider;

    public void NavigateTo<T>() where T : class
    {
        var navigateTo = _provider.GetRequiredService<T>();
        ((MainWindow)Application.Current.MainWindow).Page.Navigate(navigateTo);
    }
}
