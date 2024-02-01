namespace TGS.Core.DataServices.Tgs.Models;

public record VipLevelSnapshot
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Data { get; set; } = default!;
    public DateTimeOffset EffectiveOn { get; set; }
    public DateTimeOffset SnapshotOn { get; set; }
    public Guid SnapshotUserId { get; set; }
    public string SnapshotUsername { get; set; } = default!;
}
