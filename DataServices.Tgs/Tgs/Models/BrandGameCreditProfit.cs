using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGameCreditProfit
{
    public Guid BrandId { get; set; }

    public DateOnly Month { get; set; }

    public Guid GameProviderId { get; set; }

    public int Count { get; set; }

    public decimal Bet { get; set; }

    public decimal ValidBet { get; set; }

    public decimal Settle { get; set; }

    public decimal Commission { get; set; }

    public decimal Turnover { get; set; }

    public decimal WinLoss { get; set; }

    public decimal ProfitAmount { get; set; }
}
