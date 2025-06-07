using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StageTracker.Interfaces.Services;
using StageTracker.Interfaces.ViewModels;
using StageTracker.Services.Data;

namespace StageTracker.ViewModels.Teacher.Student;

public partial class ShowViewModel(INavigationService navigationService, RemarkDataService remarkDataService) : BaseViewModel, INavigableWithParameter
{
    [ObservableProperty]
    private Shared.ModelsEF.Student _student = default!;

    [ObservableProperty]
    private ICollectionView _remarks = default!;

    [ObservableProperty]
    private bool _isRemarkShown = false;

    private readonly INavigationService _navigationService = navigationService;

    private readonly RemarkDataService _remarkDataService = remarkDataService;

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is Shared.ModelsEF.Student student)
        {
            Student = student;
            Remarks = CollectionViewSource.GetDefaultView(Student.Remarks);
        }
        else
            _navigationService.NavigateTo<Views.Teacher.StudentsView>();
    }

    [RelayCommand]
    public void DownloadCV()
    {
        MessageBox.Show("Téléchargement du CV de " + Student?.FullName);
    }

    [RelayCommand]
    public void OpenRemark()
    {
        IsRemarkShown = true;
    }

    [RelayCommand]
    public void CloseRemark()
    {
        IsRemarkShown = false;
    }

    [RelayCommand]
    public void NewRemark()
    {
        Student.Remarks.Add(new Shared.ModelsEF.Remark
        {
            Message = "Nouvelle remarque",
            CreatedAt = DateTime.Now,
            Student = Student,
            IsEditing = true
        });
        
        Remarks.Refresh();  
    }

    [RelayCommand]
    public void EditRemark(Shared.ModelsEF.Remark remark)
    {
        if (remark is null) return;

        remark.IsEditing = true;
        remark.OriginalMessage = remark.Message;
        Remarks.Refresh();
    }

    [RelayCommand]
    public void DeleteRemark(Shared.ModelsEF.Remark remark)
    {
        if (remark is null) return;

        if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette remarque ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
        {
            Student.Remarks.Remove(remark);
            _remarkDataService.DeleteRemarkAsync(remark);
            Remarks.Refresh();
        }
    }

    [RelayCommand]
    public void ValideRemark(Shared.ModelsEF.Remark remark)
    {
        remark.IsEditing = false;

        if (remark.Id != null) _remarkDataService.UpdateRemarkAsync(remark);
        else _remarkDataService.AddRemarkAsync(remark);

        remark.OriginalMessage = remark.Message;

        Remarks.Refresh();
    }

    [RelayCommand]
    public void CancelRemark(Shared.ModelsEF.Remark remark)
    {
        if (remark.Id == null) Student.Remarks.Remove(remark);
        else
        {
            remark.Message = remark.OriginalMessage;
            remark.IsEditing = false;
        }
        
        Remarks.Refresh();
    }

    [RelayCommand]
    public void NavigateToStudentApplicationShowView(Shared.ModelsEF.Application application)
    {
        if (Student.HasApplication)
        {
            _navigationService.NavigateTo<Views.Teacher.Student.Application.ShowView>(application);
        }
    }
}
