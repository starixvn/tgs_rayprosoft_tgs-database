using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandDailyPaymentStatistics
{
    public Guid BrandId { get; set; }

    public decimal? DailyDepositAmount { get; set; }

    public int? DailyDepositApprovedCount { get; set; }

    public decimal? DailyDepositHandlingFee { get; set; }

    public int? DailyDepositRejectCount { get; set; }

    public int? DailyDepositTotalCount { get; set; }

    public decimal? DailyWithdrawAmount { get; set; }

    public decimal? DailyWithdrawHandlingFee { get; set; }

    public int DepositPlayers { get; set; }

    public int FirstDepositPlayers { get; set; }

    public DateOnly ReportDate { get; set; }

    public int UndepositAgainPlayers { get; set; }
}
