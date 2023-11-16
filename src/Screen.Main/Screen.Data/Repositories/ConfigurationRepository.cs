using EfExtensions.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Screen.Data.Context;
using Screen.Data.Interfaces;
using Screen.Data.Models;

namespace Screen.Data.Repositories;

public class ConfigurationRepository : AbstractGeneratedContextRepository<Configuration, string, ScreenDbContext> , IConfigurationRepository
{
	public ConfigurationRepository(IDbContextFactory<ScreenDbContext> dbContextFactory) : base(dbContextFactory)
	{
	}

	protected override void UpdateCollections(Configuration incoming, Configuration existing, ScreenDbContext db)
	{
		throw new NotImplementedException();
	}

	protected override void UpdateEfItem(Configuration incoming, ref Configuration existing)
	{
		throw new NotImplementedException();
	}
}