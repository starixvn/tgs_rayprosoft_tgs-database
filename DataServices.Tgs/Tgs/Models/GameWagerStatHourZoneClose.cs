using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class GameWagerStatHourZoneClose
{
    public Guid ResellerId { get; set; }

    public Guid LicenseeId { get; set; }

    public Guid BrandId { get; set; }

    public string PlayerCode { get; set; }

    public Guid GameProviderId { get; set; }

    public int GameId { get; set; }

    public DateOnly StatDayOn { get; set; }

    public TimeOnly StatHourOn { get; set; }

    public TimeSpan StatTimeSpan { get; set; }

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
