using SensorApi.Services.Interfaces;

namespace SensorApi.Middlewares
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IDeviceAuthService authService)
        {
            var isProtected = context.Request.Path.StartsWithSegments("/api/SensorReadings")
                              && context.Request.Method == HttpMethods.Post;

            if (!isProtected)
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Missing API Key");
                return;
            }

            var value = authHeader.ToString();

            var key = value.StartsWith("ApiKey ") ? value.Substring("ApiKey ".Length) : value;

            var device = await authService.GetDeviceByApiKeyAsync(key);

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
