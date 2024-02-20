using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using StudentRandomizer.Models.Collections;
using StudentRandomizer.Parsers;
using StudentRandomizer.Services;
using StudentRandomizer.ViewModels;
using StudentRandomizer.Pages;
using StudentRandomizer.Popups;
using StudentRandomizer.Views;

namespace StudentRandomizer
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMarkup()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<EditStudentsListPage>();
            builder.Services.AddTransient<EditClassesListPage>();
            builder.Services.AddSingleton<StudentsCollectionModel>();
            builder.Services.AddSingleton<ClassesCollectionModel>();
            builder.Services.AddSingleton<StudentsViewModel>();
            builder.Services.AddSingleton<ClassesViewModel>();
            builder.Services.AddSingleton<StudentsParser>();
            builder.Services.AddSingleton<ClassParser>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<StartupService>();
            builder.Services.AddSingleton<StudentsCountService>();
            builder.Services.AddSingleton<LuckyNumberService>();

            builder.Services.AddTransient<AddStudentPopup>();
            builder.Services.AddTransient<AddClassPopup>();
            builder.Services.AddTransient<AddStudentPopupViewModel>();
            builder.Services.AddTransient<AddClassPopupViewModel>();

            builder.Services.AddTransient<StudentView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
