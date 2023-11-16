using Screen.Data.Interfaces;
using Screen.Data.Models;
using Screen.Services.Interfaces.Data;

namespace Screen.Services.Implementation.Data;

public class CurrentConfigurationService : ICurrentConfigurationService
{
    private readonly IConfigurationRepository _configurationRepository;
    private readonly IMarqueeRepository _marqueeRepository;
    private readonly IPageRepository _pageRepository;
    private readonly IImageRepository _imageRepository;

    public CurrentConfigurationService(IConfigurationRepository configurationRepository,
        IMarqueeRepository marqueeRepository, IPageRepository pageRepository, IImageRepository imageRepository)
    {
        _configurationRepository = configurationRepository;
        _marqueeRepository = marqueeRepository;
        _pageRepository = pageRepository;
        _imageRepository = imageRepository;

        ConfigurationService.ItemsUpdated += (_, _) => Reload();
        Reload();
    }

    public event EventHandler? ConfigurationUpdated;

    public Configuration? CurrentConfiguration { get; set; }

    public void Reload()
    {
        CurrentConfiguration = _configurationRepository.GetCustom(x => x.Active);

        Console.WriteLine(CurrentConfiguration.ConfigurationName);

        if (CurrentConfiguration is null)
        {
            ConfigurationUpdated?.Invoke(this, EventArgs.Empty);
            return;
        }

        CurrentConfiguration.Marquees =
            _marqueeRepository.GetAllCustom(x => x.ConfigurationId == CurrentConfiguration.Id).ToList();

        CurrentConfiguration.Pages =
            _pageRepository.GetAllCustom(x => x.ConfigurationId == CurrentConfiguration.Id).OrderBy(x => x.Position)
                .ToList();

        CurrentConfiguration.EventLogo = _imageRepository.Get(CurrentConfiguration.EventLogoId);
        
            ConfigurationUpdated?.Invoke(this, EventArgs.Empty);
    }
}