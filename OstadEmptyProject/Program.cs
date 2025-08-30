var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


app.Run(async (HttpContext context) => {

    context.Response.StatusCode = 200;


    await context.Response.WriteAsync("Hello Word");
});


app.Run();
