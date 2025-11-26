using Microsoft.AspNetCore.Mvc;
using OstadFirstMVC.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<GlobalExceptionMiddleware>();



// Add services to the container.
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});


//builder.Services.AddControllersWithViews(options =>
//{
//    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware-1
// Middleware-2
// Middleware-3

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
