using System;

#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerDailyPaymentStatistics
{
    public decimal? DailyDepositAmount { get; set; }

    public int? DailyDepositCount { get; set; }

    public decimal? DailyDepositHandlingFee { get; set; }

    public decimal? DailyWithdrawAmount { get; set; }

    public int? DailyWithdrawCount { get; set; }

    public decimal? DailyWithdrawHandlingFee { get; set; }

    public decimal? FirstDepositAmount { get; set; }

    public decimal? FirstDepositHandlingFee { get; set; }

    public DateTime? FirstDepositOn { get; set; }

    public decimal? FirstWithdrawAmount { get; set; }

    public decimal? FirstWithdrawHandlingFee { get; set; }

    public DateTime? FirstWithdrawOn { get; set; }

    public string PlayerCode { get; set; } = default!;

    public DateOnly ReportDate { get; set; }

    public decimal? TotalDepositAmount { get; set; }

    public int? TotalDepositCount { get; set; }

    public decimal? TotalDepositHandlingFee { get; set; }

    public decimal? TotalWithdrawAmount { get; set; }

    public int? TotalWithdrawCount { get; set; }

    public decimal? TotalWithdrawHandlingFee { get; set; }
}
