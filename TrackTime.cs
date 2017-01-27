using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sandbox
{
    public class TrackTime : IDisposable
    {
        protected virtual Stopwatch Watch { get; } = new Stopwatch();
        string caller;

        TrackTime(string caller)
        {
            this.caller = caller;
            Watch.Start();
        }

        public override string ToString() {
            return $"{caller} takes {Watch.ElapsedMilliseconds} ms.";
        }

        public void Dispose()
        {
            Watch.Stop();
            Console.WriteLine(this);
        }

        public static IDisposable Create([CallerMemberName]string caller = null)
        {
            return new TrackTime(caller);
        }
    }
}