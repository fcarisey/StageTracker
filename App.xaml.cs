using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StageTracker.Interfaces.Services;
using StageTracker.Services;
using StageTracker.ViewModels;
using StageTracker.Views;
using System.Windows;


namespace StageTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceCollection services = new();

            //Services
            services.AddSingleton<IUserSessionService, UserSessionService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAuthService, AuthService>();

            //Data Services
            services.AddScoped<Services.Data.StudentDataService>();
            services.AddScoped<Services.Data.ClasseDataService>();
            services.AddScoped<Services.Data.TeacherDataService>();
            services.AddScoped<Services.Data.CompanyDataService>();
            services.AddScoped<Services.Data.ApplicationDataService>();
            services.AddScoped<Services.Data.RemarkDataService>();

            services.AddTransient<LoginViewModel>();

            //Admin ViewModels
            services.AddTransient<ViewModels.Admin.TeachersViewModel>();
            services.AddTransient<ViewModels.Admin.StudentsViewModel>();
            services.AddTransient<ViewModels.Admin.ClassesViewModel>();
            services.AddTransient<ViewModels.Admin.CampaniesViewModel>();
            services.AddTransient<ViewModels.Admin.Classe.AddViewModel>();
            services.AddTransient<ViewModels.Admin.Classe.ModifyViewModel>();
            services.AddTransient<ViewModels.Admin.Student.AddViewModel>();
            services.AddTransient<ViewModels.Admin.Student.ModifyViewModel>();
            services.AddTransient<ViewModels.Admin.Company.AddViewModel>();
            services.AddTransient<ViewModels.Admin.Company.ModifyViewModel>();
            services.AddTransient<ViewModels.Admin.Teacher.AddViewModel>();
            services.AddTransient<ViewModels.Admin.Teacher.ModifyViewModel>();

            //Teacher ViewModels
            services.AddTransient<ViewModels.Teacher.StudentsViewModel>();
            services.AddTransient<ViewModels.Teacher.CompaniesViewModel>();
            services.AddTransient<ViewModels.Teacher.ApplicationsViewModel>();
            services.AddTransient<ViewModels.Teacher.Company.ShowViewModel>();
            services.AddTransient<ViewModels.Teacher.Student.ShowViewModel>();
            services.AddTransient<ViewModels.Teacher.Student.Application.ShowViewModel>();

            //Admin Views
            services.AddTransient<Views.Admin.TeachersView>();
            services.AddTransient<Views.Admin.StudentsView>();
            services.AddTransient<Views.Admin.ClassesView>();
            services.AddTransient<Views.Admin.CompaniesView>();
            services.AddTransient<Views.Admin.Classe.AddView>();
            services.AddTransient<Views.Admin.Classe.ModifyView>();
            services.AddTransient<Views.Admin.Student.AddView>();
            services.AddTransient<Views.Admin.Student.ModifyView>();
            services.AddTransient<Views.Admin.Company.AddView>();
            services.AddTransient<Views.Admin.Company.ModifyView>();
            services.AddTransient<Views.Admin.Teacher.AddView>();
            services.AddTransient<Views.Admin.Teacher.ModifyView>();

            //Teacher Views
            services.AddTransient<Views.Teacher.StudentsView>();
            services.AddTransient<Views.Teacher.CompaniesView>();
            services.AddTransient<Views.Teacher.ApplicationsView>();
            services.AddTransient<Views.Teacher.Company.ShowView>();
            services.AddTransient<Views.Teacher.Student.ShowView>();
            services.AddTransient<Views.Teacher.Student.Application.ShowView>();


            services.AddTransient<MainWindow>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<LoginView>();

            services.AddDbContext<Data.DefaultDbContext>(options =>
                options.UseSqlServer("Server=FREDPO\\SQLEXPRESS01;Database=StageStracker;User Id=StageTracker;Password=812332FFed&;TrustServerCertificate=True;",
                    sqlOptions => {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: null
                        );
                    }
                )
            );


            ServiceProvider = services.BuildServiceProvider();

            MainWindow mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

            INavigationService navigationService = ServiceProvider.GetRequiredService<INavigationService>();
            navigationService.NavigateTo<LoginView>();

            mainWindow.Title = "StageTracker";
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
