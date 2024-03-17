namespace wan24.I8NGUI
{
    /// <summary>
    /// Build type
    /// </summary>
    [Flags]
    public enum BuildType
    {
        /// <summary>
        /// Windows
        /// </summary>
        Windows = 0,
        /// <summary>
        /// MAC Catalyst
        /// </summary>
        MacCatalyst = 1,
        /// <summary>
        /// iOS
        /// </summary>
        IOS = 2,
        /// <summary>
        /// Android
        /// </summary>
        Android = 3,
        /// <summary>
        /// Browser (WASM)
        /// </summary>
        Browser = 4,
        /// <summary>
        /// Debug flag
        /// </summary>
        Debug = 64,
        /// <summary>
        /// Release flag
        /// </summary>
        Release = 128,
        /// <summary>
        /// All flags
        /// </summary>
        FLAGS = Debug | Release
    }
}
