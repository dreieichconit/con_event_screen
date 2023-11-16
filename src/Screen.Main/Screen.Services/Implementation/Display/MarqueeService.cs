using Screen.Services.Interfaces.Data;
using Screen.Services.Interfaces.Display;

namespace Screen.Services.Implementation.Display;

public class MarqueeService : IMarqueeService
{
    private readonly ICurrentConfigurationService _currentConfigurationService;

    public MarqueeService(ICurrentConfigurationService currentConfigurationService)
    {
        _currentConfigurationService = currentConfigurationService;
        currentConfigurationService.ConfigurationUpdated += (_, _) => ReloadUi?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? ReloadUi;

    public string MarqueeText
    {
        get
        {
            if (_currentConfigurationService.CurrentConfiguration is { Marquees: not null })
                return string.Join(" - ", _currentConfigurationService.CurrentConfiguration.Marquees.Where(x => x.Show).OrderBy(x => x.Order).Select(x => x.Text));
            return string.Empty;
        }
    }

    public bool Scroll => _currentConfigurationService.CurrentConfiguration?.MarqueeScroll ?? false;

    public int ScrollSpeed => _currentConfigurationService.CurrentConfiguration?.MarqueeSpeed ?? 60;
}