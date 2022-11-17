using System.Globalization;
using Newtonsoft.Json;

namespace con_event_api.Classes;

public class ProgramItem
{
	[JsonProperty("event_id")]
	public string Id { get; set; }

	[JsonProperty("event_type_id")]
	public string TypeId { get; set; }

	[JsonProperty("location_id")]
	public string LocationId { get; set; }

	[JsonProperty("event_title_de")]
	public string TitleDe { get; set; }

	[JsonProperty("event_title_en")]
	public string TitleEn { get; set; }

	[JsonProperty("event_start_ts")]
	public string StartDate { get; set; }
	
	public DateTime StartStamp => DateTimeOffset.FromUnixTimeSeconds(int.Parse(StartDate)).DateTime;

	[JsonProperty("event_end_ts")]
	public string EndDate { get; set; }

	[JsonProperty("event_description_short_de")]
	public string ShortDescriptionDe { get; set; }

	[JsonProperty("event_description_short_en")]
	public string ShortDescriptionEn { get; set; }

	[JsonProperty("event_description_de")]
	public string event_description_de { get; set; }

	[JsonProperty("event_description_en")]
	public string event_description_en { get; set; }

	[JsonProperty("event_image_href_de")]
	public string event_image_href_de { get; set; }

	[JsonProperty("event_image_href_en")]
	public object event_image_href_en { get; set; }

	[JsonProperty("event_image_alt_de")]
	public string event_image_alt_de { get; set; }

	[JsonProperty("event_image_alt_en")]
	public object event_image_alt_en { get; set; }

	[JsonProperty("event_image_copy_de")]
	public object event_image_copy_de { get; set; }

	[JsonProperty("event_image_copy_en")]
	public object event_image_copy_en { get; set; }

	[JsonProperty("event_edit_ts")]
	public string event_edit_ts { get; set; }

	[JsonProperty("event_edit_id")]
	public string event_edit_id { get; set; }

	[JsonProperty("event_show")]
	public string event_show { get; set; }

	[JsonProperty("event_type_de")]
	public string event_type_de { get; set; }

	[JsonProperty("event_type_en")]
	public string event_type_en { get; set; }

	[JsonProperty("event_type_edit_ts")]
	public string event_type_edit_ts { get; set; }

	[JsonProperty("event_type_edit_id")]
	public string event_type_edit_id { get; set; }

	[JsonProperty("location_name_de")]
	public string LocationNameDe { get; set; }

	[JsonProperty("location_name_en")]
	public string location_name_en { get; set; }

	[JsonProperty("location_edit_id")]
	public string location_edit_id { get; set; }

	[JsonProperty("location_edit_ts")]
	public string location_edit_ts { get; set; }

	[JsonProperty("location_group_de")]
	public string location_group_de { get; set; }

	[JsonProperty("location_group_en")]
	public string location_group_en { get; set; }

	[JsonProperty("location_href")]
	public object location_href { get; set; }

	[JsonProperty("participants")]
	public IList<object> participants { get; set; }

	[JsonProperty("hosts")]
	public IList<object> hosts { get; set; }

	public string FormattedTimeStamp => $"{StartStamp.ToString("ddd", CultureInfo.GetCultureInfo("de-de"))} {StartStamp.ToString("t",  CultureInfo.GetCultureInfo("de-de"))}";
}