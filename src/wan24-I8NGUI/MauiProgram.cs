using Microsoft.Extensions.Logging;
using wan24.Core;

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
            Bootstrap.Async().Wait();
            Translation.Current = Translation.Dummy;
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
