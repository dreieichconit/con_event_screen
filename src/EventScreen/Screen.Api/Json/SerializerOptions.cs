using System.Text.Json;
using Screen.Api.Json.Serializers;

namespace Screen.Api.Json;

public static class SerializerOptions
{
	public static JsonSerializerOptions GetConservicesOptions()
	{
		return new JsonSerializerOptions()
		{
			Converters =
			{
				new DateTimeStringSerializer(),
			}
		};
	}
}