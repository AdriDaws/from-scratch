using FromScratch.Exceptions;

namespace FromScratch.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException ex)
        {
            logger.LogError(ex, "Not found error occurred while processing the request.");
            await HandleExceptionAsync(context, ex, 404);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while processing the request.");
            await HandleExceptionAsync(context, ex, 500);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
    {
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(exception.Message);
    }
}