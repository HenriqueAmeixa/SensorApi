using SensorApi.Services.Interfaces;

namespace SensorApi.Middlewares
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HEADER_NAME = "Authorization";

        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IDeviceAuthService authService)
        {
            if (!context.Request.Headers.TryGetValue(HEADER_NAME, out var authHeader))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Missing API Key");
                return;
            }

            var value = authHeader.ToString();
            if (!value.StartsWith("ApiKey "))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid API Key format");
                return;
            }

            var apiKey = value.Substring("ApiKey ".Length);
            var device = await authService.GetDeviceByApiKeyAsync(apiKey);

            if (device == null)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            context.Items["DeviceId"] = device.DeviceId;

            await _next(context);
        }
    }
}
