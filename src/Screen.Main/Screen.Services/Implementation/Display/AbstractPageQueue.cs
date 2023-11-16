using Screen.Data.Models;
using Serilog;

namespace Screen.Services.Implementation.Display;

public abstract class AbstractPageQueue
{
    private readonly CancellationTokenSource _tokenSource = new();

    private PeriodicTimer _timer = new (TimeSpan.FromSeconds(1));
    
    private int _currentScreenTime;
    
    private int _pageIndex;
    
    public event EventHandler? UpdateUi;
    
    public int CurrentPagination { get; set; }
    
    public Page? CurrentPage { get; set; }
    
    public bool AnimateIn { get; set; }
    
    public bool AnimateOut { get; set; }

    protected List<Page> Pages { get; set; } = new();
    
    protected void RestartTimer()
    {
        if (CurrentPage is null) return;
        
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        Task.Run(RunTimer, _tokenSource.Token);
    }

    protected virtual async Task Tick()
    {
        SetAnimation();
        if (_currentScreenTime >= CurrentPage!.SecondsVisible)
        {
            _currentScreenTime = 0;
            
            if (IsNextPageNeeded())
            {
                MoveToNextPage();
            }
            
            RefreshUi();
            return;
        }
        
        RefreshUi();
        _currentScreenTime++;
    }

    private void SetAnimation()
    {
        if (_currentScreenTime == 0)
        {
            AnimateIn = true;
            RefreshUi();
        }

        if (_currentScreenTime == 1)
        {
            AnimateIn = false;
            RefreshUi();
        }

        if (_currentScreenTime == CurrentPage!.SecondsVisible - 1)
        {
            AnimateOut = true;
            RefreshUi();
        }
        
        if (_currentScreenTime == CurrentPage!.SecondsVisible)
        {
            AnimateOut = false;
            RefreshUi();
        }
            
    }
    
    private async Task RunTimer()
    {
        RefreshUi();
        
        while (await _timer.WaitForNextTickAsync(_tokenSource.Token))
        {
            await Tick();
        }
    }

    private bool IsNextPageNeeded()
    {
        if (CurrentPagination < CurrentPage!.Pagination)
        {
            CurrentPagination++;
            return false;
        }
        
        CurrentPagination = 0;
        return true;
    }
    
    private void MoveToNextPage()
    {
        if (_pageIndex >= Pages.Count - 1) _pageIndex = 0;
        else _pageIndex++;

        CurrentPage = Pages[_pageIndex];
        SetAnimation();
    }

    private void RefreshUi() => UpdateUi?.Invoke(this, EventArgs.Empty);
}