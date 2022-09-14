namespace TGS.Core.Models.GameProviders.Settings.KY;

/// <summary>
/// KY Agent 比對
/// </summary>
public record KYAgentMapper
{
    public string CurrencyCode { get; set; }

    public string AgentId { get; set; }

    public bool Status { get; set; }
}
