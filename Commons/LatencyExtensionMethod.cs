using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Commons
{
    public static class LatencyExtensionMethod
    {
        public static IApplicationBuilder UseSimulatedLatency(this IApplicationBuilder app, TimeSpan min, TimeSpan max)
        {
            return app.UseMiddleware(
                typeof(LatencyMiddleware),
                min,
                max
            );
        }
    }
}
