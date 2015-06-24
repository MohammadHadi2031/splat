using System;
using System.Threading.Tasks;

namespace Splat
{
    /// <summary>
    /// Extension class that allows us not to require the Microsoft.Bcl.Async package
    /// in order to maintain dependencies to a minimum.
    ///
    /// The implementation respects Microsoft's implementation from
    /// https://msdn.microsoft.com/en-us/library/hh195051%28v=vs.110%29.aspx
    /// </summary>
    internal static class TaskEx
    {
        public static Task<TResult> Run<TResult>(Func<TResult> func)
        {
#if NET40
            return Task.Factory.StartNew(func, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
#else
            return Task.Run(func);
#endif
        }

        public static Task Run(Action action)
        {
#if NET40
            return Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
#else
            return Task.Run(action);
#endif
        }
    }
}
