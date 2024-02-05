#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class FiveMinutesPaymentStatisticsDelta
{
    public Guid Id { get; set; }

    public string UserId { get; set; } = null!;

    public int UserType { get; set; }

    public Guid BrandId { get; set; }

    public DateTime TimePoint { get; set; }

    public decimal DepositAmount { get; set; }

    public int DepositCount { get; set; }

    public decimal WithdrawAmount { get; set; }

    public int WithdrawCount { get; set; }

    public decimal DepositHandlingFee { get; set; }

    public decimal WithdrawHandlingFee { get; set; }
}
