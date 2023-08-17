using System.Net;
using System.Text.Json;
using tickets_net_backend.Exceptions;

namespace tickets_net_backend.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate nextRequestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _nextRequestDelegate = nextRequestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _nextRequestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            string message;
            switch (exception)
            {
                case EntityNotFoundException ex:
                    message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case InvalidIdException ex:
                    message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case InvalidTicketCategoryException ex:
                    message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case InvalidNumberOfTicketsException ex:
                    message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    message = "Internal Server Error";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError(exception, exception.Message);
            var responseBody = JsonSerializer.Serialize(new { errorMessage = message });
            await context.Response.WriteAsync(responseBody);
        }
    }
}
