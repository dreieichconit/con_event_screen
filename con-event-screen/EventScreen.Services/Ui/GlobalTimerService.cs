using EventScreen.Services.Interfaces;

namespace EventScreen.Services.Ui;

public class GlobalTimerService : IGlobalTimerService
{
	private readonly PeriodicTimer _timer;
	
	public GlobalTimerService()
	{
		_timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
		Task.Run(StartTimer);
	}
	
	public event EventHandler? SecondElapsed;
	
	public event EventHandler? HalfMinuteElapsed;
	
	public event EventHandler? MinuteElapsed;

	private async Task StartTimer()
	{
		while (await _timer.WaitForNextTickAsync(CancellationToken.None))
		{
			SecondElapsed?.Invoke(this, EventArgs.Empty);

			switch (DateTime.Now.Second)
			{
				case 30:
					HalfMinuteElapsed?.Invoke(this, EventArgs.Empty);
					break;

				case 0:
					HalfMinuteElapsed?.Invoke(this, EventArgs.Empty);
					MinuteElapsed?.Invoke(this, EventArgs.Empty);

					break;
			}
		}
	}
}