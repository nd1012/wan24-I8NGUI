using Android.App;
using Android.Runtime;

namespace wan24.I8NGUI
{
    /// <summary>
    /// Android entry point
    /// </summary>
    [Application]
    public class MainApplication : MauiApplication
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Handle</param>
        /// <param name="ownership">Ownership</param>
#pragma warning disable IDE0290 // Use primary constructor
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }
#pragma warning restore IDE0290 // Use primary constructor

        /// <inheritdoc/>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
