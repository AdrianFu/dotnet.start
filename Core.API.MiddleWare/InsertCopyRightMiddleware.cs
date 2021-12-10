using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.API.MiddleWare
{
    public class InsertCopyRightMiddleware
    {
        private readonly RequestDelegate _next;

        public InsertCopyRightMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // IMyScopedService is injected into InvokeAsync
        public async Task InvokeAsync(HttpContext httpContext, IMyScopedService svc)
        {
            svc.ReceiveTime = DateTime.Now;
            svc.Author = "Lord of weather";

            var watch = new Stopwatch();
            watch.Start();

            //To add Headers AFTER everything you need to do this
            httpContext.Response.OnStarting(state => {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add("X-Response-Time-Milliseconds", new[] { watch.ElapsedMilliseconds.ToString() });

                return Task.CompletedTask;
            }, httpContext);

            await _next(httpContext);
        }
    }
}