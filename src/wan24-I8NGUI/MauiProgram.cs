using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;

namespace wan24.I8NGUI
{
    /// <summary>
    /// MAUI app
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// Create the MAUI app
        /// </summary>
        /// <returns>MAUI app</returns>
        public static MauiApp CreateMauiApp()
        {
            BuildType build =
#if WINDOWS
                BuildType.Windows
#elif MACCATALYST
                BuildType.MacCatalyst
#elif IOS
                BuildType.IOS
#elif ANDROID
                BuildType.Android
#else
                throw new InvalidProgramException("Unknown build")
#endif
                ;
#if RELEASE
            build |= BuildType.Release;
#else
            build |= BuildType.Debug;
#endif
            var builder = MauiApp.CreateBuilder();
            RazorStartup.Start(GuiType.MAUI, build, builder.Services);
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddFluentUIComponents(options =>
            {
                options.HideTooltipOnCursorLeave = true;
                options.UseTooltipServiceProvider = true;
            });

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
