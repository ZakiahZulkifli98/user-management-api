namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        private const string ValidToken = "TechHiveToken123";

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(
                    "Authorization",
                    out var token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token required.");
                return;
            }

            if (token != ValidToken)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid token.");
                return;
            }

            await _next(context);
        }
    }
}