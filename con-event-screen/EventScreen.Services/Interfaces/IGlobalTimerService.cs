namespace EventScreen.Services.Interfaces;

public interface IGlobalTimerService
{
	public event EventHandler? SecondElapsed;
	
	public event EventHandler? HalfMinuteElapsed;
	
	public event EventHandler? MinuteElapsed;
}