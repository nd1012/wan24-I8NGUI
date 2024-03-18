namespace wan24.I8NGUI
{
    /// <summary>
    /// wan24-I8NGUI environment
    /// </summary>
    public static class GuiEnv
    {
        /// <summary>
        /// Type
        /// </summary>
        public static GuiType AppType { get; internal set; }

        /// <summary>
        /// Build
        /// </summary>
        public static BuildType AppBuild { get; internal set; }

        /// <summary>
        /// If this is a debug build
        /// </summary>
        public static bool IsDebug => (AppBuild & BuildType.Debug) == BuildType.Debug;

        /// <summary>
        /// If this is a release build
        /// </summary>
        public static bool IsRelease => !IsDebug;

        /// <summary>
        /// If this is a local app
        /// </summary>
        public static bool IsLocalApp => AppType == GuiType.MAUI;

        /// <summary>
        /// If this is a browser app (WebAssembly)
        /// </summary>
        public static bool IsBrowserApp => !IsLocalApp;
    }
}
