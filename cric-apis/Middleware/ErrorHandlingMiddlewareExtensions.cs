using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_apis.Middleware
{
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}