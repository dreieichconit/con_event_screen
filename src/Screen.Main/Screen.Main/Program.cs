using System.Globalization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Screen.Data.Context;
using Screen.Data.Interfaces;
using Screen.Data.Repositories;
using Screen.Services.Implementation.Data;
using Screen.Services.Implementation.Display;
using Screen.Services.Interfaces.Data;
using Screen.Services.Interfaces.Display;
using Serilog;

Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Verbose()
	.WriteTo.Trace()
	.WriteTo.Debug()
	.WriteTo.Console()
	.CreateLogger();

var cultureInfo = new CultureInfo("de-de");
cultureInfo.NumberFormat.CurrencySymbol = "€";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
	
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
						throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContextFactory<ScreenDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContext<ScreenDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
builder.Services.AddSingleton<IMarqueeRepository, MarqueeRepository>();
builder.Services.AddSingleton<IPageRepository, PageRepository>();
builder.Services.AddSingleton<IImageRepository, ImageRepository>();

builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IConfigurationService, ConfigurationService>();

builder.Services.AddSingleton<ICurrentConfigurationService, CurrentConfigurationService>();
builder.Services.AddKeyedSingleton<IPageQueueService, GamePageQueueService>("games");

builder.Services.AddMudServices();

var app = builder.Build();

using var db = app.Services.GetRequiredService<IDbContextFactory<ScreenDbContext>>().CreateDbContext();
db.Database.Migrate();

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

app.Run();