using SystemMetricsApi.Dto;

namespace SystemMetricsApi.Abstract.Services;

public interface ISystemInfoService
{
    public SystemInformationDto GetSystemInfo();
}
