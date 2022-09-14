using System.Text.Json.Serialization;

namespace TGS.Core.Models.GameProviders.Settings.SexyGaming;

public record SexyGamingBetLimitVenus
{
    [JsonPropertyName("LIVE")]
    public SexyGamingBetLimitVenusLive Live { get; set; }
}
