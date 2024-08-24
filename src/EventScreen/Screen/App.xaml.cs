using System.Configuration;
using System.Data;
using System.Windows;
using Screen.Startup;

namespace Screen;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);

		var host = WpfHostBuilder.Build();

		var mainWindow = new MainWindow(host);
		mainWindow.Show();
	}
}