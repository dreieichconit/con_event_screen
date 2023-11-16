using Screen.Services.Interfaces.Display;

namespace Screen.Services.Implementation.Display;

public class AlertService : IAlertService
{
	public event EventHandler? ReloadUi;

	public bool Visible { get; set; }

	public string Title { get; set; } = "ALERT";

	public string AlertText { get; set; } = "ALERT MESSAGE";

	public void Toggle()
	{
		Visible = !Visible;
		ReloadUi?.Invoke(this, EventArgs.Empty);
	}
}