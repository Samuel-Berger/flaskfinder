using System.Text.Json.Serialization;

namespace FlaskFinder;

[JsonConverter(typeof(JsonStringEnumConverter<Grape>))]
public enum Grape : int
{
    PinotNoir = 1,
    Chardonnay = 2,
}
