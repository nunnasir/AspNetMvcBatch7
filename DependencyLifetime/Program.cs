using DependencyLifetime;
using DependencyLifetime.Controllers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<TransiantOperation>();
builder.Services.AddScoped<ScopedOperation>();
builder.Services.AddSingleton<SingleTonOperation>();

builder.Services.AddSingleton<IEngine, DieselEngine>();
builder.Services.AddScoped<IEngine, PetrolEngine>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
