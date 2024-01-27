using YashilBozor.Api.Helpers;
using YashilBozor.Service.Exceptions;


namespace YashilBozor.Api.Middlewares;
public class ExceptionHandlerMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    public ExceptionHandlerMiddleWare(RequestDelegate next, ILogger<ExceptionHandlerMiddleWare> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = ex.StatusCode,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            _logger.LogError($"{ex.Message}\n\n");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = 500,
                Message = ex.Message
            });
        }
    }
}
