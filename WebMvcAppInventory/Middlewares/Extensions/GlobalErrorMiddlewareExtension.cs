namespace WebMvcAppInventory.Middlewares.Extensions;

public static class GlobalErrorMiddlewareExtension
{
    public static IApplicationBuilder UseGlobalErrorMiddleware(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseMiddleware<GlobalErrorMiddleware>();
    }
}
