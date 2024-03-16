using ObjCRuntime;
using UIKit;

namespace wan24.I8NGUI
{
    /// <summary>
    /// MAC Catalyet entry point
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Arguments</param>
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}