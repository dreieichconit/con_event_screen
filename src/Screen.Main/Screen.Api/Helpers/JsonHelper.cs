using System.Text.Json;
using Screen.Api.Converters;

namespace Screen.Api.Helpers;

public static class JsonHelper
{
    public static JsonSerializerOptions CreateConservicesConfiguration()
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