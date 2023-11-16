using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Screen.Api.Converters;

public class DateTimeStringSerializer : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.TryParse(reader.GetString()!, new CultureInfo("de-de"), out var dateTime) ? dateTime : DateTime.MaxValue;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}