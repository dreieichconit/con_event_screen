using Screen.Db.Models;

namespace Screen.Services.Interfaces;

public interface IImageService
{
    public List<Image> Images { get; set; }
    public void Reload();
    
    public bool Save();
}