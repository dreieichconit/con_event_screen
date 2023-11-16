namespace Screen.Services.Interfaces.Display;

public interface IAlertService
{
    public bool Visible { get; set; }
    
    public bool Title { get; set; }
    
    public bool AlertText { get; set; }

    public void Toggle();
}