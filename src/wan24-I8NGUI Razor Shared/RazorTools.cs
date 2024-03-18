using static wan24.Core.TranslationHelper.Ext;

namespace wan24.I8NGUI
{
    /// <summary>
    /// Razor tools
    /// </summary>
    public static class RazorTools
    {
        /// <summary>
        /// Return a value if landscape, or another value if portrait
        /// </summary>
        /// <param name="landscape">Landscape value</param>
        /// <param name="portrait">Portrait value</param>
        /// <returns>Value</returns>
        public static T? IfLandscape<T>(in T landscape, in T? portrait = default) => RazorEnv.IsLandscape ? landscape : portrait;

        /// <summary>
        /// Return a string if landscape, or another string if portrait
        /// </summary>
        /// <param name="landscape">Landscape string</param>
        /// <param name="portrait">Portrait string</param>
        /// <returns>String (may be empty, if <c>portrait</c> wasn't given)</returns>
        public static string IfLandscape(in string landscape, in string? portrait = default) => RazorEnv.IsLandscape ? landscape : portrait ?? string.Empty;

        /// <summary>
        /// Return a value if portrait, or another value if landscape
        /// </summary>
        /// <param name="portrait">Portrait value</param>
        /// <param name="landscape">Landscape value</param>
        /// <returns>Value</returns>
        public static T? IfPortrait<T>(in T portrait, in T? landscape = default) => RazorEnv.IsPortrait ? portrait : landscape;

        /// <summary>
        /// Return a string if portrait, or another string if landscape
        /// </summary>
        /// <param name="portrait">Portrait string</param>
        /// <param name="landscape">Landscape string</param>
        /// <returns>String (may be empty, if <c>landscape</c> wasn't given)</returns>
        public static string IfPortrait(in string portrait, in string? landscape = default) => RazorEnv.IsPortrait ? portrait : landscape ?? string.Empty;

        /// <summary>
        /// Return a value if having a small screen, or another value if having a large screen
        /// </summary>
        /// <param name="small">Small screen value</param>
        /// <param name="large">Large screen value</param>
        /// <returns>Value</returns>
        public static T? IfSmallScreen<T>(in T small, in T? large = default) => RazorEnv.IsSmallScreen ? small : large;

        /// <summary>
        /// Return a string if having a small screen, or another string if having a large screen
        /// </summary>
        /// <param name="small">Small screen string</param>
        /// <param name="large">Large screen string</param>
        /// <returns>String (may be empty, if <c>large</c> wasn't given)</returns>
        public static string IfSmallScreen(in string small, in string? large = default) => RazorEnv.IsSmallScreen ? small : large ?? string.Empty;

        /// <summary>
        /// Return a value if having a large screen, or another value if having a small screen
        /// </summary>
        /// <param name="large">Large screen value</param>
        /// <param name="small">Small screen value</param>
        /// <returns>Value</returns>
        public static T? IfLargeScreen<T>(in T large, in T? small = default) => !RazorEnv.IsSmallScreen ? large : small;

        /// <summary>
        /// Return a string if having a large screen, or another string if having a small screen
        /// </summary>
        /// <param name="large">Large screen string</param>
        /// <param name="small">Small screen string</param>
        /// <returns>String (may be empty, if <c>small</c> wasn't given)</returns>
        public static string IfLargeScreen(in string large, in string? small = default) => !RazorEnv.IsSmallScreen ? large : small ?? string.Empty;

        /// <summary>
        /// Show an info dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        public static Task InfoDialogAsync(in string message, in string? title = null)
            => RazorEnv.CurrentDialogService?.ShowInfoAsync(message, title ?? _("Info")) ?? Task.CompletedTask;

        /// <summary>
        /// Show an info dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        public static void InfoDialog(in string message, in string? title = null) => RazorEnv.CurrentDialogService?.ShowInfo(message, title ?? _("Info"));

        /// <summary>
        /// Show a warning dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        public static Task WarningDialogAsync(in string message, in string? title = null)
            => RazorEnv.CurrentDialogService?.ShowWarningAsync(message, title ?? _("Warning")) ?? Task.CompletedTask;

        /// <summary>
        /// Show a warning dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        public static void WarningDialog(in string message, in string? title = null) => RazorEnv.CurrentDialogService?.ShowWarning(message, title ?? _("Warning"));

        /// <summary>
        /// Show an error dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        public static Task ErrorDialogAsync(in string message, in string? title = null)
            => RazorEnv.CurrentDialogService?.ShowErrorAsync(message, title ?? _("Error")) ?? Task.CompletedTask;

        /// <summary>
        /// Show an error dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        public static void ErrorDialog(in string message, in string? title = null) => RazorEnv.CurrentDialogService?.ShowError(message, title ?? _("Error"));
    }
}
