using SystemMetricsApi.Abstract.Services;
using SystemMetricsApi.Routes;
using SystemMetricsApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandling();
builder.Services.RegisterSystemInfoService();


var app = builder.Build();
app.RegisterExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSystemMetricsEndpoints();    

app.UseHttpsRedirection();

app.Run();
