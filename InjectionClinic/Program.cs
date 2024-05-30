using InjectionClinic.Contexts;
using InjectionClinic.Controllers;
using InjectionClinic.DataDictionary;
using InjectionClinic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static InjectionClinic.Contexts.UserDBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ConnectionService>();
var configuration = builder.Configuration;

builder.Services.AddDbContext<UserDBContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DataDictionaryCreator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    name: "injectionLogin",
    pattern: "{controller=InjectionLogin}/{action=Index}/{query?}");
app.MapControllerRoute(
    name: "safeLogin",
    pattern: "{controller=SafeLogin}/{action=Index}/{query?}");

app.Run();
