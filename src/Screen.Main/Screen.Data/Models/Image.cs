using System.ComponentModel.DataAnnotations.Schema;
using EfExtensions.Items.Model;

namespace Screen.Data.Models;

public class Image : DbItem<string>
{
    public string Name { get; set; } = string.Empty;
    public required string FilePath { get; init; }

    [NotMapped]
    public string ImageSource => FilePath.Replace("./wwwroot", "");
    
    
}