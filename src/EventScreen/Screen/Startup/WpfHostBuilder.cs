using System.Net;

namespace Screen.Startup;

public static class WpfHostBuilder
{
	public static IHost Build()
	{
		var builder = Host.CreateDefaultBuilder();

		builder.ConfigureServices(
			services =>
			{
				// configure and add services here
				services.AddWpfBlazorWebView();
				services.AddBlazorWebViewDeveloperTools();
			}
		);

		builder.ConfigureWebHostDefaults(
			webBuilder =>
			{
				webBuilder.ConfigureKestrel(
					options =>
					{
						// Configure IP Options here
						options.Listen(new IPEndPoint(IPAddress.Any, 8080), config => config.UseHttps());
					}
				);

				webBuilder.UseStartup<KestrelStartup>();
			}
		);

		return builder.Build();
	}
}