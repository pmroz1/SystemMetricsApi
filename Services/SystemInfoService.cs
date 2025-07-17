using Hardware.Info;
using SystemMetricsApi.Dto;

namespace SystemMetricsApi.Services;

public class SystemInfoService(HardwareInfo hardwareInfo) : ISystemInfoService
{
    public SystemInformationDto GetSystemInfo()
    {
        hardwareInfo.RefreshAll();

        var cpus = hardwareInfo.CpuList
            .Select(cpu => new CpuDto
            {
                Name = cpu.Name,
                //Load = cpu.,
                CoreCount = (int)cpu.NumberOfCores,
                ThreadCount = (int)cpu.NumberOfLogicalProcessors
            }).ToList();

        var gpus = hardwareInfo.VideoControllerList
            .Select(gpu => new VideoControllerDto
            {
                Name = gpu.Name,
                //Load = gpu.Load,
                //Temperature = gpu.T
            }).ToList();

        var mem = hardwareInfo.MemoryStatus;
        var env = Environment.OSVersion;

        return new SystemInformationDto
        {
            HostName = Environment.MachineName,
            OsName = env.Platform.ToString(),
            OsVersion = env.VersionString,
            Architecture = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString(),
            CpuCount = Environment.ProcessorCount,
            TotalMemory = mem.TotalPhysical,
            AvailableMemory = mem.AvailablePhysical,
            Cpus = cpus,
            VideoControllers = gpus,
            Uptime = GetUptime(),
            BootTime = DateTimeOffset.Now.Subtract(TimeSpan.FromMilliseconds(Environment.TickCount64)),
            LastUpdateTime = DateTimeOffset.Now,
            SystemManufacturer = hardwareInfo.BiosList.FirstOrDefault()?.Manufacturer,
            CpuLoad = cpus.Count > 0 ? cpus.Average(x => x.Load ?? 0) : null,
            MemoryLoad = GetMemoryLoad(mem),
            GpuLoad = gpus.Count > 0 ? gpus.Average(x => x.Load ?? 0) : null,
            GpuTemperature = gpus.Count > 0 ? gpus.Average(x => x.Temperature ?? 0) : null
        };
    }


    private string GetUptime()
    {
        var uptime = TimeSpan.FromMilliseconds(Environment.TickCount64);
        return $"{(int)uptime.TotalDays}d {uptime.Hours}h {uptime.Minutes}m";
    }

    private double? GetMemoryLoad(MemoryStatus mem)
    {
        if (mem.TotalPhysical == 0) return null;
        return Math.Round(100.0 - ((double)mem.AvailablePhysical / mem.TotalPhysical * 100.0), 2);
    }
}
