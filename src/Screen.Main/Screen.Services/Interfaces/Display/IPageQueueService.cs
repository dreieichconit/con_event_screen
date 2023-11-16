using Screen.Data.Models;

namespace Screen.Services.Interfaces.Display;

public interface IPageQueueService
{
    public int CurrentPagination { get; set; }
    
    public Page? CurrentPage { get; set; }

    public event EventHandler? UpdateUi;

}