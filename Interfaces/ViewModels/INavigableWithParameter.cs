using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTracker.Interfaces.ViewModels;

public interface INavigableWithParameter
{
    public void OnNavigatedTo(object parameter);
}
