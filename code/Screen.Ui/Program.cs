using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Screen.Db.Context;
using Screen.Db.Interfaces;
using Screen.Db.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services.AddDbContextFactory<ScreenDbContext>(options => options.UseSqlite("Filename=screen.db"));

builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();

var app = builder.Build();

var dbFactory = app.Services.GetRequiredService<IDbContextFactory<ScreenDbContext>>();
var context = dbFactory.CreateDbContext();
context.Database.Migrate();

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