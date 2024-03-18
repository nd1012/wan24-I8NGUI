using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using wan24.Core;
using static wan24.Core.TranslationHelper.Ext;

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
        /// Singleton instance (used by the static <c>Show*</c> methods)
        /// </summary>
        public static ToastLogger? Instance { get; set; }

        /// <summary>
        /// Log level from which to show a dialog instead of a toast message
        /// </summary>
        public LogLevel ShowDialog { get; set; } = LogLevel.None;

        /// <summary>
        /// Information display timeout (only used for toast-display)
        /// </summary>
        public TimeSpan InfoTimeout { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Warning display timeout (only used for toast-display)
        /// </summary>
        public TimeSpan WarningTimeout { get; set; } = TimeSpan.FromSeconds(10);

        /// <summary>
        /// Error display timeout (only used for toast-display)
        /// </summary>
        public TimeSpan ErrorTimeout { get; set; } = TimeSpan.FromSeconds(20);

        /// <summary>
        /// Critical display timeout (only used for toast-display)
        /// </summary>
        public TimeSpan CriticalTimeout { get; set; } = TimeSpan.FromSeconds(40);

        /// <summary>
        /// Warning action caption (only used for toast-display)
        /// </summary>
        public string? WarningActionCaption { get; set; }

        /// <summary>
        /// Warning action callback (only used for toast-display)
        /// </summary>
        public EventCallback<ToastResult>? WarningActionCallback { get; set; }

        /// <summary>
        /// Error action caption (only used for toast-display)
        /// </summary>
        public string? ErrorActionCaption { get; set; }

        /// <summary>
        /// Error action callback (only used for toast-display)
        /// </summary>
        public EventCallback<ToastResult>? ErrorActionCallback { get; set; }

        /// <summary>
        /// Critical action caption (only used for toast-display)
        /// </summary>
        public string? CriticalActionCaption { get; set; }

        /// <summary>
        /// Critical action callback (only used for toast-display)
        /// </summary>
        public EventCallback<ToastResult>? CriticalActionCallback { get; set; }

        /// <inheritdoc/>
        protected override void LogInt<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (RazorEnv.CurrentToastService is null || logLevel < LogLevel.Information) return;
            bool dialog = ShowDialog != LogLevel.None && logLevel >= ShowDialog;
            string msg = dialog
                ? RX_NL.Replace(formatter(state, exception), Environment.NewLine)
                : formatter(state, exception).Split('\n')[0].Replace("\r", string.Empty).Replace('\t', ' ');
            switch (logLevel)
            {
                case LogLevel.Information:
                    if (dialog)
                    {
                        RazorTools.InfoDialog(msg);
                    }
                    else
                    {
                        RazorEnv.CurrentToastService.ShowInfo(msg, (int)InfoTimeout.TotalMilliseconds);
                    }
                    break;
                case LogLevel.Warning:
                    if (dialog)
                    {
                        RazorTools.WarningDialog(msg);
                    }
                    else
                    {
                        RazorEnv.CurrentToastService.ShowWarning(msg, (int)WarningTimeout.TotalMilliseconds, WarningActionCaption, WarningActionCallback);
                    }
                    break;
                case LogLevel.Error:
                    if (dialog)
                    {
                        RazorTools.ErrorDialog(msg);
                    }
                    else
                    {
                        RazorEnv.CurrentToastService.ShowError(msg, (int)ErrorTimeout.TotalMilliseconds, ErrorActionCaption, ErrorActionCallback);
                    }
                    break;
                case LogLevel.Critical:
                    if (dialog)
                    {
                        RazorTools.ErrorDialog($"{_("CRITICAL ERROR")}: {msg}");
                    }
                    else
                    {
                        RazorEnv.CurrentToastService.ShowError($"{_("CRITICAL ERROR")}: {msg}", (int)CriticalTimeout.TotalMilliseconds, CriticalActionCaption, CriticalActionCallback);
                    }
                    break;
            }
        }

#pragma warning disable CA2254 // Must not vary
        /// <summary>
        /// Show an informational toast
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowInfo(in string message, params object?[] args) => Instance?.LogInformation(message, args);

        /// <summary>
        /// Show an informational toast
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowInfo(in EventId eventId, in string message, params object?[] args) => Instance?.LogInformation(eventId, message, args);

        /// <summary>
        /// Show a warning toast
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowWarning(in string message, params object?[] args) => Instance?.LogWarning(message, args);

        /// <summary>
        /// Show a warning toast
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowWarning(in EventId eventId, in string message, params object?[] args) => Instance?.LogWarning(eventId, message, args);

        /// <summary>
        /// Show a warning toast
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowWarning(in Exception ex, in string message, params object?[] args) => Instance?.LogWarning(ex, message, args);

        /// <summary>
        /// Show a warning toast
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="ex">Exception</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowWarning(in EventId eventId, in Exception ex, in string message, params object?[] args)
            => Instance?.LogWarning(eventId, ex, message, args);

        /// <summary>
        /// Show an error toast
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowError(in string message, params object?[] args) => Instance?.LogError(message, args);

        /// <summary>
        /// Show an error toast
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowError(in EventId eventId, in string message, params object?[] args) => Instance?.LogError(eventId, message, args);

        /// <summary>
        /// Show an error toast
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowError(in Exception ex, in string message, params object?[] args) => Instance?.LogError(ex, message, args);

        /// <summary>
        /// Show an error toast
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="ex">Exception</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowError(in EventId eventId, in Exception ex, in string message, params object?[] args)
            => Instance?.LogError(eventId, ex, message, args);

        /// <summary>
        /// Show a critical toast
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowCritical(in string message, params object?[] args) => Instance?.LogCritical(message, args);

        /// <summary>
        /// Show a critical toast
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowCritical(in EventId eventId, in string message, params object?[] args) => Instance?.LogCritical(eventId, message, args);

        /// <summary>
        /// Show a critical toast
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowCritical(in Exception ex, in string message, params object?[] args) => Instance?.LogCritical(ex, message, args);

        /// <summary>
        /// Show a critical toast
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="ex">Exception</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        public static void ShowCritical(in EventId eventId, in Exception ex, in string message, params object?[] args)
            => Instance?.LogCritical(eventId, ex, message, args);
#pragma warning restore CA2254 // Must not vary
    }
}
