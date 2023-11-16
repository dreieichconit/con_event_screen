using EfExtensions.Items.Model;
using Screen.Data.Enum;

namespace Screen.Data.Models;

public class Page : DbItem<string>
{
	public required string ConfigurationId { get; set; }
	
	public required PageType PageType { get; set; }
	
	public int Position { get; set; }
	
	public int ItemsPerPage { get; set; }
	
	public int Pagination { get; set; }
	
	public int SecondsVisible { get; set; }

	public string RequestUri { get; set; } = string.Empty;
	
	public DataFormat? DataFormat {get; set;}
}