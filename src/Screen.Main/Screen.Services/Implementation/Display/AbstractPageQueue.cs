using Screen.Data.Models;

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

    protected List<Page> Pages { get; set; } = new();
    
    protected void RestartTimer()
    {
        if (CurrentPage is null) return;
        
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        Task.Run(RunTimer, _tokenSource.Token);
    }

    protected virtual async Task Tick()
    {
        if (_currentScreenTime >= CurrentPage!.SecondsVisible)
        {
            if (IsNextPageNeeded())
            {
                MoveToNextPage();
            }
            
            RefreshUi();
            _currentScreenTime = 0;
            return;
        }
        
        RefreshUi();
        _currentScreenTime++;
    }
    
    private async Task RunTimer()
    {
        while (await _timer.WaitForNextTickAsync(_tokenSource.Token))
        {
            await Tick();
        }
    }

    private bool IsNextPageNeeded()
    {
        if (CurrentPage!.Pagination >= CurrentPagination)
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
    }

    private void RefreshUi() => UpdateUi?.Invoke(this, EventArgs.Empty);
}