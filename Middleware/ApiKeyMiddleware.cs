

namespace SystemMetricsApi.Middleware;

public class ApiKeyMiddleware(
    RequestDelegate next,
    IConfiguration configuration
)
{
    private readonly string apiKey = configuration.GetValue<string>("ApiKey") ?? throw new ArgumentNullException();

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("X-API-KEY", out var providedKey) || providedKey != apiKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await next(context);
    }
}
