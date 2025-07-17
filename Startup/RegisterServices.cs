using SystemMetricsApi.Middleware;

namespace SystemMetricsApi.Startup;

public static class RegisterServices
{
    public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        return services;
    }

    public static WebApplication RegisterExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler();
        return app;
    }
}
