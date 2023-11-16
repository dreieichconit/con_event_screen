using EfExtensions.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Screen.Data.Context;
using Screen.Data.Interfaces;
using Screen.Data.Models;

namespace Screen.Data.Repositories;

public class PageRepository : AbstractGeneratedContextRepository<Page, string, ScreenDbContext>, IPageRepository
{
	public PageRepository(IDbContextFactory<ScreenDbContext> dbContextFactory) : base(dbContextFactory)
	{
	}

	protected override void UpdateCollections(Page incoming, Page existing, ScreenDbContext db)
	{
		throw new NotImplementedException();
	}

	protected override void UpdateEfItem(Page incoming, ref Page existing)
	{
		throw new NotImplementedException();
	}
}