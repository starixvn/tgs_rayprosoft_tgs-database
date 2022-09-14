using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class GameProviderCurrency
{
    public virtual Currency Currency { get; set; }

    public string CurrencyCode { get; set; }

    public virtual GameProvider GameProvider { get; set; }

    public string GameProviderCurrencyCode { get; set; }

    public Guid GameProviderId { get; set; }
}
