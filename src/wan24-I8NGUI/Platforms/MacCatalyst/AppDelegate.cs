using Foundation;

namespace wan24.I8NGUI
{
    /// <summary>
    /// MAC Catalyst app delegate
    /// </summary>
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        /// <inheritdoc/>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
