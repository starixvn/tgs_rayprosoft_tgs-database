using TGS.Core.Models.GameProviders.Settings.BigGaming;

namespace TGS.Core.Models.GameProviders.Settings;

/// <summary>
/// BG 設定檔案
/// </summary>
public record BigGamingConfiguration : PluggableConfigurationBase
{
    public BigGamingBrandMerchant[] BrandMerchants { get; set; }
    public OppositeBetSetting[] OppositeBets { get; init; }
}
