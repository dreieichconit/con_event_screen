using EfExtensions.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Screen.Data.Context;
using Screen.Data.Interfaces;
using Screen.Data.Models;

namespace Screen.Data.Repositories;

public class ImageRepository : AbstractGeneratedContextRepository<Image, string, ScreenDbContext>, IImageRepository
{
    public ImageRepository(IDbContextFactory<ScreenDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }

    protected override void UpdateCollections(Image incoming, Image existing, ScreenDbContext db)
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEfItem(Image incoming, ref Image existing)
    {
        throw new NotImplementedException();
    }
}