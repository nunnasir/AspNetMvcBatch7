using Microsoft.Extensions.Caching.Memory;

namespace MiddlewareExample.Middleware;

public class IpRateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly MemoryCache _cache = new(new MemoryCacheOptions());

    private const int LIMTIT = 5;
    private static readonly TimeSpan WINDOW = TimeSpan.FromMinutes(1);

    public IpRateLimitingMiddleware(RequestDelegate next)
    {
        _next = next;

        
    }

    public void Invoke(HttpContext context)
    {
        string ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        string key = $"rateLimit_{ip}";

        var counter = _cache.GetOrCreate(key, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = WINDOW;
            return 0;
        });

        if (counter >= LIMTIT)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            context.Response.WriteAsync($"Too Many Requests with {ip}. Please try again later.");
            return;
        }

        _cache.Set(key, counter + 1);

        _next(context);
    }
}

// Requirement
// Per IP: Limit to 5 requests per minute
// 10:45 -> 10:46 : 5 requests allowed
// 10:45 -> 10:46 : 8 requests not allowed
// 10:46 -> 10:47 : 5 requests allowed
