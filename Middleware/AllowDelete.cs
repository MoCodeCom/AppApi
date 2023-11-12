using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appapi.Middleware
{
    public class AllowDelete
    {
            private readonly RequestDelegate _next;

            public AllowDelete(RequestDelegate next)
            {
                _next = next;
            }

            public Task Invoke(HttpContext httpContext)
            {
                
                return _next(httpContext);
            }        
    }
}