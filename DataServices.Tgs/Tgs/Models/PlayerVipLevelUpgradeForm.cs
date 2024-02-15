namespace TGS.Core.DataServices.Tgs.Models;

public record PlayerVipLevelUpgradeForm
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string PlayerCode { get; set; }
    public int VipLevel { get; set; }
    public int State { get; set; }
    public decimal Amount { get; set; }
    public decimal ActualAmount { get; set; }
    public string Remark { get; set; }
    public string SnapshotVipLevel { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid CreatedUserId { get; set; }
    public string CreatedUsername { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
    public Guid UpdatedUserId { get; set; }
    public string UpdatedUsername { get; set; }
}
