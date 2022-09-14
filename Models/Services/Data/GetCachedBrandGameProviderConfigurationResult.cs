using System;

namespace TGS.Core.Models.Services.Data;

public class GetCachedBrandGameProviderConfigurationResult
{
    public string DefaultLanguageCode { get; set; }

    public string DesktopQueryString { get; set; }

    public Guid GameProviderConfigurationId { get; set; }

    public string MobileQueryString { get; set; }
}
