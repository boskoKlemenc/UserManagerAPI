using UserManagerAPI.Services;

namespace UserManagerAPI.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeaderName = "X-AUTH-KEY";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration, IApiClientService apiClientService)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Response.StatusCode = 401; //return unauthorized if no key is present
                await context.Response.WriteAsync("AUTH Key is missing.");
                return;
            }

            //check if client with this api key exists and is active
            var apiClient = await apiClientService.GetByApiKeyAsync(extractedApiKey);
            if (!(apiClient != null && apiClient.IsActive))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }

            await _next(context);
        }
    }
}
