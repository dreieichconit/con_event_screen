namespace Screen.Services.Interfaces.Display;

public interface IMarqueeService
{
    public event EventHandler? ReloadUi;
    
    public string MarqueeText { get; }
    
    public bool Scroll { get; }
}