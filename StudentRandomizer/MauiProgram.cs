using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using StudentRandomizer.Models.Collections;
using StudentRandomizer.Parsers;
using StudentRandomizer.Services;
using StudentRandomizer.ViewModels;

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

            builder.Services.AddSingleton<StudentsCollectionModel>();
            builder.Services.AddSingleton<ClassesCollectionModel>();
            builder.Services.AddSingleton<StudentsViewModel>();
            builder.Services.AddSingleton<StudentsParser>();
            builder.Services.AddSingleton<ClassParser>();

            builder.Services.AddSingleton<StartupService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
