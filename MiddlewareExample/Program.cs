using MiddlewareExample.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

// Request -> M1 -> M2 -> M3 -> Enpoint -> Response

// Request -> M1->M2->M3
// Response -> M1 <- M2 <- M3


// Middleware - M1
app.Use(async (context, next) =>
{
    Console.WriteLine("Before M1");
    await next();
    Console.WriteLine("After M1");
});

// Middleware - M2
app.Use(async (context, next) =>
{
    Console.WriteLine("Before M2");
    await next();
    Console.WriteLine("After M2");
});

// Middleware - M3
app.Use(async (context, next) =>
{
    Console.WriteLine("Before M2");
    await next();
    Console.WriteLine("After M2");
});


//app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();


// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-9.0