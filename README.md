# SystemMetricsApi

![Build Status](https://github.com/YOUR_USERNAME/SystemMetricsApi/actions/workflows/ci-cd.yml/badge.svg)

A lightweight .NET 8 API for retrieving system metrics including CPU and memory information.

## Features

- Real-time system metrics
- API key authentication
- Self-contained deployment
- Swagger documentation

## Quick Start

### Running locally
```bash
dotnet run
```

### API Usage
```bash
curl -H "X-API-KEY: your-secret-key" https://localhost:7000/metrics
```

## Configuration

Set your API key in `appsettings.json`:
```json
{
  "ApiKey": "your-secret-key"
}
```

## Build Status

The project uses GitHub Actions for CI/CD. The badge above shows the current build status.