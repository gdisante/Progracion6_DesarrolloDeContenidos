using Progracion6_DesarrolloDeContenidos.Middlewares;

namespace Progracion6_DesarrolloDeContenidos.Extensions
{
    public static class UseErrorHandlerMiddleware
    {
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
