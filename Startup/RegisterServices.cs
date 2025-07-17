using SystemMetricsApi.Middleware;

namespace SystemMetricsApi.Startup;

public static class RegisterServices
{
    public static WebApplication RegisterExceptionHandlingMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        return app;
    }
}
