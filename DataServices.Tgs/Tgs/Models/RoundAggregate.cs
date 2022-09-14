using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class RoundAggregate
{
    public Guid? AgentId { get; set; }

    public decimal BetAmount { get; set; }

    public Guid BrandId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public int GameId { get; set; }

    public Guid GameProviderId { get; set; }

    public GameType GameType { get; set; }

    public int Hour { get; set; }

    public int Id { get; set; }

    public int Minute { get; set; }

    public decimal OriginalTurnover { get; set; }

    public string PlayerCode { get; set; }

    public DateTimeOffset ReportDate { get; set; }

    public decimal Turnover { get; set; }

    public decimal ValidBetAmount { get; set; }

    public decimal WinLoss { get; set; }
}
