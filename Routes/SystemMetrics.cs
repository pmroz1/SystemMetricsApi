using SystemMetricsApi.Abstract.Services;

namespace SystemMetricsApi.Routes;

public static class SystemMetrics
{
    public static void MapSystemMetricsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/metrics", (ISystemInfoService systemInfo) =>
            systemInfo.GetSystemInfo())
            .WithName("GetSystemMetrics");
    }
}