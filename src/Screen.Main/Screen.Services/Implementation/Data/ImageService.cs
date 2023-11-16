using EfExtensions.Core.Interfaces.Result;
using Screen.Data.Interfaces;
using Screen.Data.Models;
using Screen.Services.Interfaces.Data;
using Screen.Services.Util;

namespace Screen.Services.Implementation.Data;

public class ImageService(IImageRepository imageRepository) : IImageService
{
    public List<Image> Items { get; set; } = new();
    
    public IEnumerable<IDbResult<Image>> Save()
    {
        return imageRepository.CrudMany(Items);
    }

    public void Load()
    {
        Items = imageRepository.GetAll().SetUpdated().ToList();
    }
}