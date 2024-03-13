namespace TGS.Core.DataServices.Tgs.Models;

public record GameWagerMarker
{
    public string Code { get; set; }
    public Guid Marker { get; set; }
    public string Expansions { get; set; }
    public string Directions { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
}
