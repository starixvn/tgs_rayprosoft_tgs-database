using System;
using System.Threading;
using System.Threading.Tasks;

namespace TGS.Core.Infrastructures.Helper;

public static class AsyncHelper
{
    private static readonly TaskFactory _TaskFactory = new(CancellationToken.None,
        TaskCreationOptions.None,
        TaskContinuationOptions.None,
        TaskScheduler.Default);

    public static void RunAsync(Func<Task> func)
    {
        _ = _TaskFactory
            .StartNew(func)
            .Unwrap();
    }

    public static void RunAsync(Action action)
    {
        _ = Task.Run(action);
    }

    public static void RunAsync(Func<object, Task> func, object arg0)
    {
        _ = _TaskFactory
            .StartNew(func, arg0)
            .Unwrap();
    }

    public static CancellationTokenSource RunLongRunningAsync(Func<CancellationToken, Task> func)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        _ = _TaskFactory
            .StartNew(() =>
                    func(cancellationTokenSource.Token),
                cancellationTokenSource.Token,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default)
            .Unwrap();
        return cancellationTokenSource;
    }

    public static TResult RunSync<TResult>(Func<Task<TResult>> func)
    {
        return _TaskFactory
            .StartNew(func)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
    }

    public static void RunSync(Func<Task> func)
    {
        _TaskFactory
            .StartNew(func)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
    }
}
