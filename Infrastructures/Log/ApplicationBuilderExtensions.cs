using System.Linq;
using Microsoft.AspNetCore.Builder;
using TGS.Core.Infrastructures.Log.Middleware;

namespace TGS.Core.Infrastructures.Log;

public static class ApplicationBuilderExtensions
{
    [Obsolete("過時")]
    public static IApplicationBuilder UseApiLogger(this IApplicationBuilder app, string logPrefix = "",
        string[] bypassRouting = null)
    {
        _ = app.UseWhen(context => bypassRouting == null ||
            bypassRouting.All(
                r => !context.Request.Path.StartsWithSegments(r)),
            builder => builder.UseMiddleware<ApiLoggerMiddleware>(logPrefix));

        return app;
    }

    [Obsolete("過時")]
    public static IApplicationBuilder UseGameApiLogger(this IApplicationBuilder app, string logPrefix = "",
        string[] bypassRouting = null)
    {
        _ = app.UseWhen(context => bypassRouting == null ||
                bypassRouting.All(
                    r => !context.Request.Path.StartsWithSegments(r)),
                    builder => builder.UseMiddleware<GameApiLoggerMiddleware>(logPrefix));

        return app;
    }
}
