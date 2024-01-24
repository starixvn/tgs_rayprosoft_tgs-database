namespace TGS.Core.DataServices.Tgs.Models;

public record PlayerVipLevelExp
{
    public string PlayerCode { get; set; } = default!;

    public decimal AccumDeposit { get; set; } = default!;
    public decimal AccumTurnover { get; set; } = default!;
    public Guid AccumDepositId { get; set; } = default!;
    public Guid AccumTurnoverId { get; set; } = default!;
}
