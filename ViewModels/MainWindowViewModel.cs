using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using StageTracker.Interfaces.Services;
using StageTracker.Services;
using System.Windows;

namespace StageTracker.ViewModels;

public partial class MainWindowViewModel : BaseViewModel
{
    [ObservableProperty]
    private IUserSessionService _session;

    private readonly INavigationService _navigation;

    public MainWindowViewModel(IUserSessionService session, INavigationService navigation) 
    {
        Title = "Main Window";
        Description = "Main Window of the application";
        _session = session;
        _navigation = navigation;
    }

    
    [RelayCommand]
    public void NavigateToAdminClassesView() 
    {
        _navigation.NavigateTo<Views.Admin.ClassesView>();
    }
    
    [RelayCommand]
    public void NavigateToAdminTeachersView() 
    {
        _navigation.NavigateTo<Views.Admin.TeachersView>();
    }
    
    [RelayCommand]
    public void NavigateToAdminCompaniesView() 
    {
        _navigation.NavigateTo<Views.Admin.CompaniesView>();
    }
    
    [RelayCommand]
    public void NavigateToAdminStudentsView() 
    {
        _navigation.NavigateTo<Views.Admin.StudentsView>();
    }



    [RelayCommand]
    public void NavigateToTeacherClassesView() 
    {
        _navigation.NavigateTo<Views.Teacher.ApplicationsView>();
    }

    [RelayCommand]
    public void NavigateToTeacherCompaniesView() 
    {
        _navigation.NavigateTo<Views.Teacher.CompaniesView>();
    }

    [RelayCommand]
    public void NavigateToTeacherStudentsView()
    {
         _navigation.NavigateTo<Views.Teacher.StudentsView>();
    }
}
