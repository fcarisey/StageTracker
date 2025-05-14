using CommunityToolkit.Mvvm.ComponentModel;
using StageTracker.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTracker.ViewModels.Teacher.Company;

public partial class ShowViewModel : BaseViewModel, INavigableWithParameter
{
    [ObservableProperty]
    private Models.Company? _company;

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Models.Company company)
        {
            Company = company;
            Title = $"Company - {company.Name}";
        }
        else
        {
            throw new ArgumentException("Parameter must be of type Models.Company", nameof(parameter));
        }
    }
}
