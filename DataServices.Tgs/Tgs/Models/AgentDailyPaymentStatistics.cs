using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDailyPaymentStatistics
{
    public Guid AgentId { get; set; }

    public Guid BrandId { get; set; }

    public decimal? DailyDepositAmount { get; set; }

    public decimal? DailyDepositHandlingFee { get; set; }

    public decimal? DailyWithdrawAmount { get; set; }

    public decimal? DailyWithdrawHandlingFee { get; set; }

    public int DepositPlayers { get; set; }

    public int FirstDepositPlayers { get; set; }

    public DateOnly ReportDate { get; set; }

    public int UndepositAgainPlayers { get; set; }
}
