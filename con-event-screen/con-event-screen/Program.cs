using con_event_db.Context;
using con_event_screen.Data;
using con_event_services.Classes;
using con_event_services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<ScreenDbContext>(options => options.UseSqlite("Data Source=ApiDb.db"));

builder.Services.AddSingleton<IStateController, StateController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Trace()
    .WriteTo.Console()
    .CreateLogger();

app.Run();