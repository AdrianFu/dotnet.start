using Microsoft.AspNetCore.Builder;

namespace Core.API.MiddleWare
{
    public static class InsertCopyRightMiddlewareExtensions
    {
        public static IApplicationBuilder UseInsertCopyRight(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InsertCopyRightMiddleware>();
        }
    }
}