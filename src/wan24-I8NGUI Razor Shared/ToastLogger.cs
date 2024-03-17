using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using wan24.Core;

namespace wan24.I8NGUI
{
    /// <summary>
    /// Toast logger
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="logLevel">Log level</param>
    /// <param name="next">Next</param>
    public sealed class ToastLogger(in LogLevel logLevel = LogLevel.Information, in ILogger? next = null) : LoggerBase(logLevel, next)
    {
        /// <summary>
        /// Toast service
        /// </summary>
        public static IToastService? Toast { get; set; }

        /// <summary>
        /// Information display timeout
        /// </summary>
        public TimeSpan InfoTimeout { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Warning display timeout
        /// </summary>
        public TimeSpan WarningTimeout { get; set; } = TimeSpan.FromSeconds(10);

        /// <summary>
        /// Error display timeout
        /// </summary>
        public TimeSpan ErrorTimeout { get; set; } = TimeSpan.FromSeconds(20);

        /// <summary>
        /// Critical display timeout
        /// </summary>
        public TimeSpan CriticalTimeout { get; set; } = TimeSpan.FromSeconds(40);

        /// <summary>
        /// Warning action caption
        /// </summary>
        public string? WarningActionCaption { get; set; }

        /// <summary>
        /// Warning action callback
        /// </summary>
        public EventCallback<ToastResult>? WarningActionCallback { get; set; }

        /// <summary>
        /// Error action caption
        /// </summary>
        public string? ErrorActionCaption { get; set; }

        /// <summary>
        /// Error action callback
        /// </summary>
        public EventCallback<ToastResult>? ErrorActionCallback { get; set; }

        /// <summary>
        /// Critical action caption
        /// </summary>
        public string? CriticalActionCaption { get; set; }

        /// <summary>
        /// Critical action callback
        /// </summary>
        public EventCallback<ToastResult>? CriticalActionCallback { get; set; }

        /// <inheritdoc/>
        protected override void LogInt<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (Toast is null || logLevel < LogLevel.Information) return;
            string msg = RX_NL.Replace(formatter(state, exception), $"{Environment.NewLine}\t");
            switch (logLevel)
            {
                case LogLevel.Information:
                    Toast.ShowInfo(msg, (int)InfoTimeout.TotalMilliseconds);
                    break;
                case LogLevel.Warning:
                    Toast.ShowWarning(msg, (int)WarningTimeout.TotalMilliseconds, WarningActionCaption, WarningActionCallback);
                    break;
                case LogLevel.Error:
                    Toast.ShowError(msg, (int)ErrorTimeout.TotalMilliseconds, ErrorActionCaption, ErrorActionCallback);
                    break;
                case LogLevel.Critical:
                    Toast.ShowError($"CRITICAL ERROR: {msg}", (int)CriticalTimeout.TotalMilliseconds, CriticalActionCaption, CriticalActionCallback);
                    break;
            }
        }
    }
}
