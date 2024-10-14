namespace WebApiRouteResponses.Middlewares
{
    public class StatusMiddleware
    {
        readonly RequestDelegate next;
        public StatusMiddleware(RequestDelegate requestDelegate)
        {
            next = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await next(httpContext);
            if (httpContext.Request.Query.Any(p => p.Key == "Status"))
            {
                await httpContext.Response.WriteAsync("Working...");
            }

        }
    }

    public static class StatusMiddlewareExtension 
    {
        public static IApplicationBuilder UseStatusMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StatusMiddleware>();
        }
    }
}