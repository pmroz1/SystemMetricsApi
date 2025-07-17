namespace SystemMetricsApi.Middleware;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger
){
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e) {
            logger.LogError(e, "An unhandled exception occurred while processing the request.");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            var errorResponse = new
            {
                Message = "An unexpected error occurred. Please try again later."
            };
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
