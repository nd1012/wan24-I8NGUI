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
        /// <returns>String (may be empty, if <c>portrait</c> wasn't given)</returns>
        public static string IfPortrait(in string portrait, in string? landscape = default) => RazorEnv.IsPortrait ? portrait : landscape ?? string.Empty;
    }
}
