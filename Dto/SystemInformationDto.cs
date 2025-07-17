using Hardware.Info;

namespace SystemMetricsApi.Dto;

public class SystemInformationDto
{
    public string? HostName { get; set; }
    public string? OsName { get; set; }
    public string? OsVersion { get; set; }
    public string? Architecture { get; set; }
    public int CpuCount { get; set; }
    public ulong TotalMemory { get; set; }
    public ulong AvailableMemory { get; set; }

    public List<CpuDto>? Cpus { get; set; }
    public List<VideoControllerDto>? VideoControllers { get; set; }

    public string? Uptime { get; set; }
    public DateTimeOffset? BootTime { get; set; }
    public DateTimeOffset? LastUpdateTime { get; set; }
    public string? SystemManufacturer { get; set; }

    public double? CpuLoad { get; set; }
    public double? MemoryLoad { get; set; }
    public double? GpuLoad { get; set; }
    public double? GpuTemperature { get; set; }
}


public class CpuDto
{
    public string? Name { get; set; }
    public double? Load { get; set; } // Will usually be null, unless available
    public int CoreCount { get; set; }
    public int ThreadCount { get; set; }
}

public class VideoControllerDto
{
    public string? Name { get; set; }
    public double? Load { get; set; } // Will usually be null
    public double? Temperature { get; set; } // Will usually be null
}