using System;
using TGS.Core.Models.GameProviders.Settings.SexyGaming;

namespace TGS.Core.Models.GameProviders.Settings;

public record SexyGamingConfiguration : PluggableConfigurationBase
{
    public Uri ApiUrl { get; init; }
    public string AgentId { get; init; }
    public string Cert { get; init; }
    public SexyGamingBetLimit BetLimit { get; init; }
    public OppositeBetSetting[] OppositeBets { get; init; }
}
