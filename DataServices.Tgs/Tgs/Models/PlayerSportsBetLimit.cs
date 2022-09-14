using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerSportsBetLimit
{
    public int MaxBet { get; set; }

    public int MaxBetPerMatch { get; set; }

    public int MinBet { get; set; }

    public virtual Player Player { get; set; }

    public string PlayerCode { get; set; }

    public virtual SportMarketType SportMarketType { get; set; }

    public Guid SportMarketTypeId { get; set; }
}
