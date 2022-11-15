﻿namespace con_event_services.Interfaces;

public interface IStateController
{
    public event EventHandler? SecondElapsed;
    
    public event EventHandler? HalfMinuteElapsed;
    
    public event EventHandler? MinuteElapsed;

    public event EventHandler? RedAlert;

    public event EventHandler? MarqueeUpdated;

    public void TriggerMarquee();

    public void TriggerAlert();
}