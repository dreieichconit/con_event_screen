using Screen.Db.Interfaces;
using Screen.Db.Models;
using Screen.Services.Interfaces;

namespace Screen.Services.Implementation;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
        Reload();
    }

    public List<Image> Images { get; set; } = new();

    public void Reload()
    {
        Images = _imageRepository.GetAll().ToList();
    }

    public bool Save()
    {
        var results = _imageRepository.CrudMany(Images);
        return results.All(x => x.Success);
    }
}