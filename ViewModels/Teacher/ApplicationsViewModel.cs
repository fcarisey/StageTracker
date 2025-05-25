using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Services.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace StageTracker.ViewModels.Teacher;

public partial class ApplicationsViewModel : BaseViewModel
{

    [ObservableProperty]
    private ObservableCollection<Models.Application> _applications = default!;

    [ObservableProperty]
    private ICollectionView _filteredApplications = default!;

    private readonly ApplicationDataService _applicationDataService;

    public ApplicationsViewModel(ApplicationDataService applicationDataService)
    {
        _applicationDataService = applicationDataService;

        _ = LoadApplicationsAsync();

    }

    private async Task LoadApplicationsAsync()
    {
        var applications = await _applicationDataService.GetAllApplicationsAsync();
        Applications = new ObservableCollection<Models.Application>(applications);
        FilteredApplications = CollectionViewSource.GetDefaultView(Applications);
    }

    [RelayCommand]
    public void OnTextChanged(string searchTerms)
    {
        if (!string.IsNullOrEmpty(searchTerms) && searchTerms.Length > 0)
        {
            searchTerms = searchTerms.Trim();
            FilteredApplications.Filter = x =>
            {
                if (x is Models.Application application)
                {
                    if (application != null)
                    {
                        return application.Student.FirstName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                application.Student.LastName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                application.Internship.Title.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                application.Status.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                                application.Internship.Company.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase);
                    }
                }

                return false;
            };

            FilteredApplications.Refresh();
        }
        else
        {
            FilteredApplications.Filter = null;
            FilteredApplications.Refresh();
        }  
    }
}
