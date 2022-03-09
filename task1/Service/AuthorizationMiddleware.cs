using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Service
{
    /// <summary>
    /// 2.2.4.**	Добавьте Middleware, который запретит делать запрос, без хедера “Authorization” со значением “Basic admin:admin”.
    /// </summary>
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var header = context.Request.Query["Authorization"];
            if (header != "Basic admin:admin")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Authorization is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}

