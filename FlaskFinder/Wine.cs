namespace FlaskFinder;

public class Wine
{
    public required long Id { get; set; }
    public required string Producer { get; set; }
    public required string Label { get; set; }
    public required DateOnly? Vintage { get; set; }
    public required decimal AlcoholByVolume { get; set; }
    public required Container Container { get; set; }
    public required IEnumerable<Blend> Grapes { get; set; }
}

public record WineDto(string id);