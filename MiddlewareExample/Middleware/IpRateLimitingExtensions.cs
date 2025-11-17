namespace MiddlewareExample.Middleware
{
    public static class IpRateLimitingExtensions
    {
        public static IApplicationBuilder UseIpRateLimiting(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IpRateLimitingMiddleware>();
        }
    }
}
