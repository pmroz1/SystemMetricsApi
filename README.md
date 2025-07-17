# SystemMetricsApi

A simple ASP.NET Core Web API for collecting and exposing system metrics.

## Requirements

- .NET 8.0 SDK

## Setup

1. Clone the repository:
   ```powershell
   git clone <repository-url>
   cd SystemMetricsApi
   ```
2. Restore dependencies and build:
   ```powershell
   dotnet restore; dotnet build
   ```
3. Run the API:
   ```powershell
   dotnet run
   ```

## Usage

Use an HTTP client or the `SystemMetricsApi.http` file for example requests. The API exposes endpoints under `/metrics` to retrieve system information.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
