
using System.Net;
using System.Text.Json;
using API.Exceptions;

namespace API.Middlewares;


public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        var statusCode = e switch
        {
            InvalidCredentialsException => HttpStatusCode.Unauthorized,
            UserAlreadyExistsException => HttpStatusCode.Conflict,
            _ => HttpStatusCode.InternalServerError
        };

        var response = new
        {
            error = e.Message
        };
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}