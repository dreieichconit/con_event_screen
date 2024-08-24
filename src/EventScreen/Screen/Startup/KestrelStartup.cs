
using MudBlazor.Services;
using Screen.Api.Interfaces;
using Screen.Api.Repository;
using Screen.Services.Interfaces;
using Screen.Services.Services;

namespace Screen.Startup;

public class KestrelStartup
{
	public void ConfigureServices(IServiceCollection services)
	{
		// configure additional services which depend on the services in the HostBuilder to be initialized
		services.AddMudServices();
		services.AddAuthentication();

		services.AddSingleton<IConservicesGameRepository, ConservicesGameRepository>();
		services.AddSingleton<IConservicesGameService, ConservicesGameService>();
	}

	public void Configure(IApplicationBuilder app)
	{
		// use this method to configure your application
		// this is the section which is usually at the end of the Program.cs file in a Blazor application.
		app.UseAuthentication();

		app.UseRouting();
		app.UseHttpsRedirection();
		app.UseStaticFiles();
	}
}