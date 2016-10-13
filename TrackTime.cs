using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sandbox
{
    public class TrackTime : IDisposable
    {
        Stopwatch sw = Stopwatch.StartNew ();

        string caller;

        TrackTime (string caller)
        {
            this.caller = caller;
        }

        public void Dispose ()
        {
            Console.WriteLine ($"{caller} takes {sw.ElapsedMilliseconds} ms.");
        }

        public static IDisposable Create ([CallerMemberName]string caller = null)
        {
            return new TrackTime (caller);
        }
    }
}
