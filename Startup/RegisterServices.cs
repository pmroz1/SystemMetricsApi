using Hardware.Info;
using SystemMetricsApi.Abstract.Services;
using SystemMetricsApi.Middleware;
using SystemMetricsApi.Services;

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

    public static IServiceCollection RegisterSystemInfoService(this IServiceCollection services)
    {
        services.AddScoped<Hardware.Info.HardwareInfo>();
        services.AddScoped<ISystemInfoService, SystemInfoService>();
        return services;
    }
}
