using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerPaymentOverview
{
    public decimal? FirstDepositAmount { get; set; }

    public decimal? FirstDepositHandlingFee { get; set; }

    public DateTime? FirstDepositOn { get; set; }

    public decimal? FirstWithdrawAmount { get; set; }

    public decimal? FirstWithdrawHandlingFee { get; set; }

    public DateTime? FirstWithdrawOn { get; set; }

    public decimal? FisrtDepositAmount { get; set; }

    public string PlayerCode { get; set; }

    public DateOnly RecordedBy { get; set; }

    public decimal TotalDepositAmount { get; set; }

    public decimal TotalWithdrawAmount { get; set; }
}
