namespace Screen.Services.Interfaces.Display;

public interface IAlertService
{
    public event EventHandler? ReloadUi;
    
    public bool Visible { get; set; }
    
    public string Title { get; set; }
    
    public string AlertText { get; set; }

    public void Toggle();
}