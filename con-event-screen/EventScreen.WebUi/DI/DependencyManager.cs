using EventScreen.Db.Models.Settings;
using EventScreen.Db.Repositories;
using EventScreen.Db.Repositories.Interfaces;
using EventScreen.Services.Interfaces;
using EventScreen.Services.Settings;
using EventScreen.Services.Ui;

namespace EventScreen.WebUi.DI;

public static class DependencyManager
{
	public static void InjectServices(IServiceCollection collection)
	{
		collection.AddSingleton<IScreenSettingsRepository, ScreenSettingsRepository>();
		collection.AddSingleton<IScreenRepository, ScreenRepository>();
		collection.AddSingleton<IPagesService, PagesService>();
		
		collection.AddSingleton<IGlobalTimerService, GlobalTimerService>();

		collection.AddSingleton<IPageManagerService, PageManagerService>();
	}
}