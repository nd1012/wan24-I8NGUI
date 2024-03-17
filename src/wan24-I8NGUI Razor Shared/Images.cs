using Microsoft.FluentUI.AspNetCore.Components;

namespace wan24.I8NGUI
{
    /// <summary>
    /// Used Fluent-UI image assets
    /// </summary>
    public static class Images
    {
        /// <summary>
        /// Home icon
        /// </summary>
        /// <param name="active">If active</param>
        /// <returns>Icon</returns>
        public static Icon HomeIcon24(bool active = false) => active ? new Icons.Filled.Size24.Home() : new Icons.Regular.Size24.Home();

        public static Icon CounterIcon24(bool active = false) => active ? new Icons.Filled.Size24.ArrowCounterclockwise() : new Icons.Regular.Size24.ArrowCounterclockwise();

        public static Icon WeatherIcon24(bool active = false) => active ? new Icons.Filled.Size24.Cloud() : new Icons.Regular.Size24.Cloud();
    }
}
