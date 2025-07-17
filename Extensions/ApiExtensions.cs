using SystemMetricsApi.Results;

namespace SystemMetricsApi.Extensions;

public static class ApiExtensions
{
    public static IResult ToApiResult<T>(this Result<T> result){
        if(result.Success)
        {
            return TypedResults.Ok(result.Data);
        }
        else
        {
            return TypedResults.Problem(result.Message);
        }
    }
}
