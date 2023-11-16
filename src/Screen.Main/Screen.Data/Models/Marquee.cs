using EfExtensions.Items.Model;

namespace Screen.Data.Models;

public class Marquee : DbItem<string>
{
	public required string ConfigurationId { get; set; }
	
	public int Order { get; set; }

	public string Text { get; set; } = string.Empty;
	
	public bool Show { get; set; }
}