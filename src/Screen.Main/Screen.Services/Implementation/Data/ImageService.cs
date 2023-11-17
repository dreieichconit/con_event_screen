using EfExtensions.Core.Interfaces.Result;
using Screen.Data.Interfaces;
using Screen.Data.Models;
using Screen.Services.Interfaces.Data;
using Screen.Services.Util;

namespace Screen.Services.Implementation.Data;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    
    public List<Image> Items { get; set; } = new();
    
    public IEnumerable<IDbResult<Image>> Save()
    {
        return _imageRepository.CrudMany(Items);
    }

    public void Load()
    {
        Items = _imageRepository.GetAll().SetUpdated().ToList();
    }
}