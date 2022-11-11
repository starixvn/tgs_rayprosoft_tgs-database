#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionType
{
    public string? Extend { get; set; }

    public string Name { get; set; } = default!;

    public string? Translate { get; set; }
}
