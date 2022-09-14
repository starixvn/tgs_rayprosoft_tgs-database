using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class GameProviderLanguage
{
    public string CultureCode { get; set; }

    public virtual GameProvider GameProvider { get; set; }

    public string GameProviderCultureCode { get; set; }

    public Guid GameProviderId { get; set; }

    public virtual Language Language { get; set; }
}
