using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class GameTypeRoundAggregate
{
    public Guid BrandId { get; set; }
    public Guid? AgentId { get; set; }
    public int VipLevel { get; set; }
    public string PlayerCode { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public Guid GameProviderId { get; set; }
    public int GameId { get; set; }
    public GameType GameType { get; set; }
    public decimal BetAmount { get; set; }
    public decimal OriginalTurnover { get; set; }
    public decimal Turnover { get; set; }
    public decimal ValidBetAmount { get; set; }
    public decimal WinLoss { get; set; }
    public int RoundCount { get; set; }
    public DateTime CreatedOn { get; set; }
}