using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class GameWagerStatBrandClose
{
    public Guid ResellerId { get; set; }

    public Guid LicenseeId { get; set; }

    public Guid BrandId { get; set; }

    public Guid GameProviderId { get; set; }

    public DateTimeOffset StatOn { get; set; }

    public int Count { get; set; }

    public decimal Bet { get; set; }

    public decimal ValidBet { get; set; }

    public decimal Settle { get; set; }

    public decimal Commission { get; set; }

    public decimal Turnover { get; set; }

    public decimal WinLoss { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}
