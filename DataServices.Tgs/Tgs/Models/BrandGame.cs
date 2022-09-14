using System;
using System.Collections.Generic;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGame
{
    public virtual Brand Brand { get; set; }

    public virtual ICollection<BrandGroupGame> BrandGroups { get; set; }

    public Guid BrandId { get; set; }

    public int DisplayOrder { get; set; }

    public decimal EffectiveBettingPercentage { get; set; }

    public virtual Game Game { get; set; }

    public int GameId { get; set; }

    public Guid Id { get; set; }

    public bool Rebate { get; set; }

    public GameStatus Status { get; set; }

    public GameTag Tag { get; set; }
}
