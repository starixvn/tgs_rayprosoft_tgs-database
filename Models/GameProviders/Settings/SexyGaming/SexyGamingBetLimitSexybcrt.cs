using System.Text.Json.Serialization;

namespace TGS.Core.Models.GameProviders.Settings.SexyGaming;

public record SexyGamingBetLimitSexybcrt
{
    [JsonPropertyName("LIVE")]
    public SexyGamingBetLimitSexybcrtLive Live { get; set; }
}
