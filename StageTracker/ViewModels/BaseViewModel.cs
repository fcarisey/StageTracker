using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTracker.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    public string _description = string.Empty;

    public BaseViewModel() => _description = this.GetType().Name;
}
