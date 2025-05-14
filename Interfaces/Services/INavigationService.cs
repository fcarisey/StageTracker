using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTracker.Interfaces.Services;

public interface INavigationService
{
    public void NavigateTo<TView>() where TView : class;
    public void NavigateTo<T>(object parameter) where T : class;
}
