using System.Text.Json.Serialization;

namespace TGS.Core.Models.GameProviders.Settings.SexyGaming;

public record SexyGamingBetLimitSexybcrtLive
{
    [JsonPropertyName("limitId")]
    public int[] LimitId { get; set; }
}
