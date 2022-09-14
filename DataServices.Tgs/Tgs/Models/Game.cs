using System;
using System.Collections.Generic;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class Game : BaseEntity<int>
{
    /// <summary>
    ///     Currencies that the game supports, recorded by csv format
    ///     Empty for all currencies that game provider has.
    /// </summary>
    public string AvailableCurrencies { get; set; }

    public bool AvailableToBrand { get; set; }

    public virtual ICollection<BrandGame> Brands { get; set; }

    public string Description { get; set; }

    public string EndpointPath { get; set; }

    public string ExternalId { get; set; }

    public virtual GameProvider GameProvider { get; set; }

    public Guid GameProviderId { get; set; }

    public bool HasTurnoverOnTieBet { get; set; }

    public bool Html5 { get; set; }

    public string Localization { get; set; }

    public GamePlatformType PlatformType { get; set; }

    public string RuleUrl { get; set; }

    public GameStatus Status { get; set; }

    public bool SubGame { get; set; }

    public virtual SubGameProvider SubGameProvider { get; set; }

    public string SubGameProviderCode { get; set; }

    public GameType Type { get; set; }
}
