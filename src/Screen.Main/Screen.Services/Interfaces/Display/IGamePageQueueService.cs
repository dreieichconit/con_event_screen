using Screen.Data.Models;

namespace Screen.Services.Interfaces.Display;

public interface IGamePageQueueService
{
    public int CurrentPagination { get; set; }
    
    public bool AnimateIn { get; set; }
    
    public bool AnimateOut { get; set; }
    
    public Page? CurrentPage { get; set; }

    public event EventHandler? UpdateUi;

}