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
    }
}
