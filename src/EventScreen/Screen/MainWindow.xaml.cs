using System.ComponentModel;

namespace Screen;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
	private readonly IHost _host;

	/// <summary>
	/// Root index.html document.
	/// Found in the Blazor UI Template Projects wwwroot
	/// </summary>
	public static string RootPage => "wwwroot/index.html";

	public MainWindow(IHost host)
	{
		_host = host;

		InitializeComponent();

		Resources.Add("services", _host.Services);

		_ = _host.StartAsync(CancellationToken.None);
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		_host.Dispose();
		base.OnClosing(e);
	}
}