using Screen.Data.Enum;
using Screen.Data.Models;
using Screen.Services.Interfaces.Data;
using Screen.Services.Interfaces.Display;

namespace Screen.Services.Implementation.Display;

public class MainPageQueueService : AbstractPageQueue, IPageQueueService
{
    private readonly ICurrentConfigurationService _configService;

    public MainPageQueueService(ICurrentConfigurationService configService)
    {
        _configService = configService;
        _configService.ConfigurationUpdated += (_, _) => Reload();
        Reload();
    }

    private void Reload()
    {
        Pages = _configService.CurrentConfiguration?.Pages.Where(x => x.PageType != PageType.Games).ToList() ?? new List<Page>();
        CurrentPage = Pages.FirstOrDefault();
        RestartTimer();
    }

}