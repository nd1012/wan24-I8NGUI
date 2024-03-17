using Microsoft.FluentUI.AspNetCore.Components;

namespace wan24.I8NGUI
{
    /// <summary>
    /// Razor environment
    /// </summary>
    public static class RazorEnv
    {
        /// <summary>
        /// Screen orientation
        /// </summary>
        public static Orientation ScreenOrientation { get; set; } = Orientation.Horizontal;

        /// <summary>
        /// Inverse screen orientation
        /// </summary>
        public static Orientation InverseScreenOrientation => ScreenOrientation switch
        {
            Orientation.Horizontal => Orientation.Vertical,
            _ => Orientation.Horizontal
        };

        /// <summary>
        /// Is landscape screen orientation?
        /// </summary>
        public static bool IsLandscape => ScreenOrientation == Orientation.Horizontal;

        /// <summary>
        /// Is portrait screen orientation?
        /// </summary>
        public static bool IsPortrait => ScreenOrientation == Orientation.Vertical;

        /// <summary>
        /// Window width in pixel
        /// </summary>
        public static int WindowWidth { get; set; }

        /// <summary>
        /// Window height in pixel
        /// </summary>
        public static int WindowHeight { get; set; }
    }
}
