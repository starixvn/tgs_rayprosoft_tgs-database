// ReSharper disable CheckNamespace
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

using System;
using System.Collections.Generic;
using System.Linq;
using TGS.Core.Infrastructures.Extensions;
using TGS.Core.Models.GameProviders.Settings;
using GameProviderConst = TGS.Core.Models.Consts.GameProvider;

namespace TGS.Core.DataServices.Tgs.DataInitializers;

public partial class DataInitializer
{
    internal record SabaGameProvider : IGameProvider
    {
        private const int UniqueId = 6;

        private static readonly string _EndpointPath = "?token={GPTOKEN}&tsId={TOKENID}";
        private readonly IGame[]? _games;

        public SabaGameProvider()
        {
            _games = LoadGamesFromCsv(GameProviderConst.Saba)
                ?.Select(g => g.EndpointPath.IsNotNullOrEmpty() ? g : ((Game)g with { EndpointPath = _EndpointPath }))
                .ToArray();
        }

        Guid IGameProvider.Id => new("09D8D244-206B-4030-8110-B2EA90DC9D2F");

        string IGameProvider.Code => GameProviderConst.Saba;

        string IGameProvider.Name => "Saba Sports";

        IGameProviderConfiguration[] IGameProvider.GameProviderConfigurations =>
        [
            new SabaGameProviderConfiguration()
        ];

        ICurrency[] IGameProvider.Currencies =>
        [
            new CNYCurrency("13"),
            new USDCurrency("3"),
            new VND1000Currency("51"),
            new IDR1000Currency("15"),
            new JPYCurrency("32"),
            new KRWCurrency("45"),
            new MYRCurrency("2"),
            new THBCurrency("4"),
            new GBPCurrency("12")
        ];

        ILanguage[] IGameProvider.Languages =>
        [
            new USLanguage("en"),
            new CNLanguage("cs"),
            new IDLanguage("id"),
            new JPLanguage("jp"),
            new KRLanguage("ko"),
            new THLanguage("th"),
            new VNLanguage("vn"),
            new TWLanguage("ch")
        ];

        IGame[]? IGameProvider.Games => _games;

        bool IGameProvider.AllowKickPlayer => false;

        ushort IGameProvider.UniqueId => UniqueId;

        GameProviderBetLimit[] IGameProvider.BetLimits => [];

        PluggableConfigurationBase IGameProvider.GetConfiguration() =>
            new SabaConfiguration
            {
                ServiceEndpointUrl = new Uri("http://localhost:62330"),
                OperatorId = "ZhiFeng055",
                VendorId = "zzdaa12nu1",
                SecretKey = "zzdaa12nu1",
                ApiUrl = new("http://t829tsa.bw6688.com"),
                TestEnvironments = new[]
                {
                    "development",
                    "staging"
                }
            };

        Dictionary<string, string> IGameProvider.SportTypes => [];

        Dictionary<string, string> IGameProvider.MarketTypes => [];

        SubGameProvider[] IGameProvider.SubGameProviders =>
        [
            new(GameProviderConst.Saba, "Saba Sports")
        ];
    }

    internal record SabaGameProviderConfiguration : IGameProviderConfiguration
    {
        private static readonly string _Endpoint = "http://sbtest.l0093.owsb66.com/deposit_processlogin.aspx";

        Guid IGameProviderConfiguration.Id => new("E3F6CD9F-20BA-4824-86A6-562B135440E1");

        string IGameProviderConfiguration.Name => "Configuration Saba";

        string IGameProviderConfiguration.ClientId => "Saba-PG";

        string IGameProviderConfiguration.SecretKey => "k6JgvabfqlneVTfM9pxmOK14WnmkxQBf";

        string IGameProviderConfiguration.DesktopEndpoint => _Endpoint;

        string IGameProviderConfiguration.MobileEndpoint => _Endpoint;
    }
}
