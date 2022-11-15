using System.Diagnostics;
using con_event_services.Interfaces;
using Serilog;

namespace con_event_services.Classes;

public class StateController : IStateController
{
    private readonly PeriodicTimer _timer;
    
    public StateController()
    {
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        Task.Run(StartTimer);
    }

    public event EventHandler? SecondElapsed;
    public event EventHandler? HalfMinuteElapsed;
    public event EventHandler? MinuteElapsed;
    public event EventHandler? RedAlert;
    public event EventHandler? MarqueeUpdated;

    public void TriggerAlert()
    {
        RedAlert?.Invoke(null, EventArgs.Empty);
    }

    public void TriggerMarquee()
    {
        MarqueeUpdated?.Invoke(null, EventArgs.Empty);
    }
    
    private async Task StartTimer()
    {

        while (await _timer.WaitForNextTickAsync(CancellationToken.None))
        {
            SecondElapsed?.Invoke(null, EventArgs.Empty);

            if (DateTime.Now.Second == 30)
            {
                HalfMinuteElapsed?.Invoke(null, EventArgs.Empty);
            }
            
            else if (DateTime.Now.Second == 0)
            {
                HalfMinuteElapsed?.Invoke(null, EventArgs.Empty);
                MinuteElapsed?.Invoke(null, EventArgs.Empty);
            }
        }
    }
}