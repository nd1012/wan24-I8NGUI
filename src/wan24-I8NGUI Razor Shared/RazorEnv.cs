using Microsoft.FluentUI.AspNetCore.Components;

namespace wan24.I8NGUI
{
    /// <summary>
    /// Razor environment
    /// </summary>
    public static class RazorEnv
    {
        /// <summary>
        /// Max. small screen width in pixel
        /// </summary>
        public const int SMALL_SCREEN_WIDTH = 480;
        /// <summary>
        /// Landscape screen orientation
        /// </summary>
        public const Orientation LANDSCAPE_ORIENTATION = Orientation.Horizontal;
        /// <summary>
        /// Portrait screen orientation
        /// </summary>
        public const Orientation PORTRAIT_ORIENTATION = Orientation.Vertical;

        /// <summary>
        /// Screen orientation
        /// </summary>
        public static Orientation ScreenOrientation => WindowHeight > WindowWidth
            ? PORTRAIT_ORIENTATION// Portrait
            : LANDSCAPE_ORIENTATION;// Landscape (for square, also)

        /// <summary>
        /// Inverse screen orientation
        /// </summary>
        public static Orientation InverseScreenOrientation => ScreenOrientation switch
        {
            LANDSCAPE_ORIENTATION => PORTRAIT_ORIENTATION,
            _ => LANDSCAPE_ORIENTATION
        };

        /// <summary>
        /// Is landscape screen orientation?
        /// </summary>
        public static bool IsLandscape => ScreenOrientation == LANDSCAPE_ORIENTATION;

        /// <summary>
        /// Is portrait screen orientation?
        /// </summary>
        public static bool IsPortrait => ScreenOrientation == PORTRAIT_ORIENTATION;

        /// <summary>
        /// Window width in pixel
        /// </summary>
        public static int WindowWidth { get; set; } = int.MaxValue;

        /// <summary>
        /// Window height in pixel
        /// </summary>
        public static int WindowHeight { get; set; } = int.MaxValue;

        /// <summary>
        /// If there's a small screen
        /// </summary>
        public static bool IsSmallScreen => IsLandscape? WindowHeight <= SMALL_SCREEN_WIDTH : WindowWidth <= SMALL_SCREEN_WIDTH;

        /// <summary>
        /// If there's a large screen
        /// </summary>
        public static bool IsLargeScreen => !IsSmallScreen;

        /// <summary>
        /// Current toast service
        /// </summary>
        public static IToastService? CurrentToastService { get; set; }

        /// <summary>
        /// Current dialog service
        /// </summary>
        public static IDialogService? CurrentDialogService { get; set; }
    }
}
