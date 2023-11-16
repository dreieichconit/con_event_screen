using EfExtensions.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Screen.Data.Context;
using Screen.Data.Interfaces;
using Screen.Data.Models;

namespace Screen.Data.Repositories;

public class MarqueeRepository : AbstractGeneratedContextRepository<Marquee, string, ScreenDbContext>, IMarqueeRepository
{
	public MarqueeRepository(IDbContextFactory<ScreenDbContext> dbContextFactory) : base(dbContextFactory)
	{
	}

	protected override void UpdateCollections(Marquee incoming, Marquee existing, ScreenDbContext db)
	{
		throw new NotImplementedException();
	}

	protected override void UpdateEfItem(Marquee incoming, ref Marquee existing)
	{
		throw new NotImplementedException();
	}
}