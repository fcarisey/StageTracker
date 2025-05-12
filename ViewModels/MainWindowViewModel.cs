using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using StageTracker.Services;
using System.Windows;

namespace StageTracker.ViewModels;

public partial class MainWindowViewModel : BaseViewModel
{

    private IServiceProvider _provider;

    [ObservableProperty]
    private UserSessionService _session;

    public MainWindowViewModel(UserSessionService session, IServiceProvider provider) 
    {
        Title = "Main Window";
        Description = "Main Window of the application";
        _provider = provider;
        _session = session;
    }

    
    [RelayCommand]
    public void NavigateToAdminClassesViewCommand() 
    {
        var classesAdminView = _provider.GetRequiredService<Views.Admin.ClassesView>();
        ((MainWindow)Application.Current.MainWindow).Page.Navigate(classesAdminView);
    }
    
    [RelayCommand]
    public void NavigateToAdminTeachersViewCommand() 
    {
        var teachersAdminView = _provider.GetRequiredService<Views.Admin.TeachersView>();
        ((MainWindow)Application.Current.MainWindow).Page.Navigate(teachersAdminView);
    }
    
    [RelayCommand]
    public void NavigateToAdminCompaniesViewCommand() 
    {
        var CompaniesAdminView = _provider.GetRequiredService<Views.Admin.CompaniesView>();
        ((MainWindow)Application.Current.MainWindow).Page.Navigate(CompaniesAdminView);
    }
    
    [RelayCommand]
    public void NavigateToAdminStudentsViewCommand() 
    {
        var StudentsAdminView = _provider.GetRequiredService<Views.Admin.StudentsView>();
        ((MainWindow)Application.Current.MainWindow).Page.Navigate(StudentsAdminView);
    }



    [RelayCommand]
    public void NavigateToTeacherClassesViewCommand() 
    {
        var TeacherClassesView = _provider.GetRequiredService<Views.Teacher.ApplicationsView>();
        ((MainWindow)Application.Current.MainWindow).Page.Navigate(TeacherClassesView);
    }

    [RelayCommand]
    public void NavigateToTeacherCompaniesViewCommand() 
    {
        var TeacherCompaniesView = _provider.GetRequiredService<Views.Teacher.CompaniesView>();
        ((MainWindow)Application.Current.MainWindow).Page.Navigate(TeacherCompaniesView);
    }

    [RelayCommand]
    public void NavigateToTeacherStudentsViewCommand()
    {
        var TeacherStudentsView = _provider.GetRequiredService<Views.Teacher.StudentsView>();
        ((MainWindow)Application.Current.MainWindow).Page.Navigate(TeacherStudentsView);
    }
}
