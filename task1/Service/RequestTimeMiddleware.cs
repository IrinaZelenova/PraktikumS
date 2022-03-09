using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Service
{
    /// <summary>
    /// 2.2.3.**	Добавьте Middleware, который будет логировать с помощью ILogger (стандартная реализация) время начала запроса и время завершения запроса
    /// </summary>
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
       

        public RequestTimeMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });
            ILogger logger = loggerFactory.CreateLogger<Startup>();

            logger.LogInformation("Time start:{0}", DateTime.Now);
            
            await _next.Invoke(context);
           
           logger.LogInformation("Time end:{0}", DateTime.Now); ;

            

        }
    }
}

