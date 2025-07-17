using Microsoft.OpenApi.Models;
using SystemMetricsApi.Abstract.Services;
using SystemMetricsApi.Routes;
using SystemMetricsApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddExceptionHandling();
builder.Services.RegisterSystemInfoService();


var app = builder.Build();
app.RegisterExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.SetupApiKeyMiddleware();
app.MapSystemMetricsEndpoints();    

app.UseHttpsRedirection();

app.Run();
