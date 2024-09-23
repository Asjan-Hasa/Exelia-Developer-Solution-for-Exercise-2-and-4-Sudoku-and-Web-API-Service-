using Models;
using System.Net;
using System.Text;

namespace BeerCollection.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unhandled exception occurred in : {context.Request.Path}");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                // Create a response object with the error information
                var errorResponse = new ErrorResponse
                {
                    Message = $"An unhandled exception occurred in : {context.Request.Path}",
                    Details = ex.InnerException == null ? ex.Message : ex.InnerException.Message,
                    ErrorLocation = SimplifyStackTrace(ex.StackTrace ?? ""),
                    // You can add more properties to the ErrorResponse as needed
                };

                // Serialize the response object and write it to the response body
                var responseJson = System.Text.Json.JsonSerializer.Serialize(errorResponse);
                context.Response.ContentLength = Encoding.UTF8.GetBytes(responseJson).Length;

                await context.Response.WriteAsync(responseJson, Encoding.UTF8);
            }
        }
        private string SimplifyStackTrace(string stackTrace)
        {
            try
            {
                var contentPath = _environment.ContentRootPath;
                int lastIndexContentPath = contentPath.TrimEnd('\\').LastIndexOf('\\');
                string finalContentPath = contentPath[..lastIndexContentPath];
                // Split the stack trace by line breaks
                var lines = stackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                // Find the first line that contains the project's root directory
                var rootLine = lines.FirstOrDefault(line => line.Contains("line"));

                if (rootLine != null)
                {
                    // Extract the file path and method name from the root line
                    var startIndex = rootLine.IndexOf(" in ") + 4;
                    var endIndex = rootLine.Length;

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        //var filePath = rootLine.Substring(startIndex, endIndex - startIndex);
                        stackTrace = rootLine.Replace(finalContentPath, "").Trim();
                    }
                }

                return stackTrace; // Return the original stack trace if simplification fails
            }
            catch
            {
                return stackTrace;
            }

        }
    }
}
