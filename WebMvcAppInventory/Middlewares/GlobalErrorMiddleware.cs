using System.Net;
using WebMvcAppInventory.Models;
using System.Text.Json;

namespace WebMvcAppInventory.Middlewares;

public class GlobalErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalErrorMiddleware> _logger;

    public GlobalErrorMiddleware(RequestDelegate next, ILogger<GlobalErrorMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.StackTrace);

            //context.Response.Redirect("Home/Error");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ResultModel result = new ResultModel()
            {
                Success = false,
                Message = ex.Message,
            };

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
