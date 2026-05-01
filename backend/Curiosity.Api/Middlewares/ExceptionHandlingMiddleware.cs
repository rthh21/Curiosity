using System.Net;
using System.Text.Json;

namespace Curiosity.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Lăsăm request-ul să meargă mai departe în controllere
                await _next(context);
            }
            catch (Exception ex)
            {
                // Dacă bubuie ceva, prindem eroarea aici și o logăm
                _logger.LogError(ex, "A apărut o eroare neașteptată în aplicație.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is KeyNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return context.Response.WriteAsync(JsonSerializer.Serialize(new { 
                    error = "Eroare 404." 
                }));
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonSerializer.Serialize(new { 
                error = "Eroare 500." 
            }));
        }
    }
}