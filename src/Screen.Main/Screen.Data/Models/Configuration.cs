using System.ComponentModel.DataAnnotations.Schema;
using EfExtensions.Items.Model;

namespace Screen.Data.Models;

public class Configuration : DbItem<string>
{
	public string ConfigurationName { get; set; } = string.Empty;
	
	public bool Active { get; set; }
	
	public bool MarqueeScroll { get; set; }
	
	public string EventLogoId { get; set; }
	
	[NotMapped]
	public Image? EventLogo { get; set; }

	[NotMapped]
	public List<Marquee> Marquees { get; set; } = new();

	[NotMapped]
	public List<Page> Pages { get; set; } = new();
}