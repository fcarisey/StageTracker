using CommunityToolkit.Mvvm.ComponentModel;

namespace StageTracker.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    public string _description = string.Empty;

    public BaseViewModel() => _description = this.GetType().Name;
}
