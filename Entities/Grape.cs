using System.Text.Json.Serialization;

namespace Entities;

[JsonConverter(typeof(JsonStringEnumConverter<Grape>))]
public enum Grape : int
{
    PinotNoir = 1,
    Chardonnay = 2,
}
