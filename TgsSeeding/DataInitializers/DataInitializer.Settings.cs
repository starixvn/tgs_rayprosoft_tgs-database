using System.Text.Json;
using TGS.Core.DataServices.Tgs.Models;
using TGS.Core.Infrastructures.Extensions;
using TGS.Core.Models;
using TGS.Core.Models.Services;
using TGS.Core.Models.Settings;

namespace TGS.Core.DataServices.Tgs.DataInitializers;

public partial class DataInitializer
{
    private static Setting CreateSetting(string key, string value, string description) =>
        new()
        {
            Key = key,
            Value = value,
            Description = description,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername,
            CreatedOn = _Now,
            UpdatedOn = _Now
        };

    private static ArrearsEmail GetArrearsEmail() =>
        new()
        {
            Manager = new()
            {
                Emails =
                [
                    "rico.lin@rayprosoft.com"
                ],
                Subject = "Manager",
                Content =
                    "HI Manager, \r\n '{0}'."
            },
            SettlementDay = new()
            {
                Subject = "settlementDay",
                Content =
                    "settlementDay hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'."
            },
            Daily =
            [
                new()
                {
                    Subject = "60%",
                    SendPercentage = 60.0M,
                    Content =
                        "60% hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'."
                },
                new()
                {
                    Subject = "70%",
                    SendPercentage = 70.0M,
                    Content =
                        "70% hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'."
                },
                new()
                {
                    Subject = "80%",
                    SendPercentage = 80.0M,
                    Content =
                        "80% hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'."
                },
                new()
                {
                    Subject = "90%",
                    SendPercentage = 90.0M,
                    Content =
                        "90% hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'. \r\n hi please pay for arrears '{0}'."
                }
            ]
        };

    private static MenuSetting[] GetMenuSettings() =>
    [
        new("Overview", [
            new("Platform", [
                new("View")
            ]) 
        ]),
        new("Platform", [
            new("Banner", [
                new("View"),
                new("Create"),
                new("Update"),
                new("Verify")
            ]),
            new("Announcement", [
                new("View"),
                new("Create"),
                new("Update"),
                new("Verify")
            ]),
            new("StationLetter", [
                new("View"),
                new("Create"),
                new("Verify")
            ]),
            new("VipLevel", [
                new("View"),
                new("Create"),
                new("Update")
            ]),
            new("IMSettings", [
                new("View"),
                new("Update"),
                new("ViewLiveChat"),
                new("UpdateLiveChat"),
                new("ViewAllAgent"),
                new("UpdateAllAgent"),
                new("ViewSms"),
                new("UpdateSms"),
                new("ViewPlayerContactField"),
                new("UpdatePlayerContactField")
            ]),
            new("IPAddress", [
                new("View")
            ]),
            new("Letter", [
                new("View"),
                new("Update")
            ])
        ]),
        new("Promotion", [
            new("PromotionList", [
                new("View"),
                new("Update"),
                new("ChangeLog")
            ]),
            new("PayoutList", [
                new("View"),
                new("Update")
            ]),
            new("WinningList", [
                new("View")
            ])
        ]),
        new("PlayerManagement", [
            new("PlayerList", [
                new("View"),
                new("Update"),
                new("PhoneFilter"),
                new("Contact"),
                new("DepositForm"),
                new("WithdrawalForm"),
                new("BalanceChangeUnsaved"),
                new("EditIdNumber"),
                new("UpgradeToAgent"),
                new("Bank")
            ]),
            new("PlayerIdentity", [
                new("View"),
                new("Update")
            ]),
            new("BalanceAdjustment", [
                new("View"),
                new("Update"),
                new("SystemTransactionType"),
                new("BatchAddBalance"),
                new("AdjustLockedAmount"),
                new("AdjustTransactionAmount")
            ]),
            new("OnlinePlayerList", [
                new("View")
            ])
        ]),
        new("AgentManagement", [
            new("AgentList", [
                new("View"),
                new("Update"),
                new("UpdateDomain"),
                new("UpdateIngress"),
                new("UpdateDnsZone"),
                new("ClearProfitShare"),
                new("ChangeWithdrawalPassword"),
                new("ProductFee")
            ]),
            new("BalanceAdjustment", [
                new("View"),
                new("Update"),
                new("SystemTransactionType")
            ])
        ]),
        new("Game", [
            new("BrandProviders", [
                new("View"),
                new("Update")
            ]),
            new("BrandGames", [
                new("View"),
                new("Update"),
                new("ViewDetail"),
                new("UpdateDetail")
            ])
        ]),
        new("Report", [
            new("MarketReport", [
                new("View")
            ]),
            new("OrderReport", [
                new("View")
            ]),
            new("OpenRound", [
                new("View")
            ]),
            new("AgentContributionReport", [
                new("View")
            ]),
            new("PlayerContributionReport", [
                new("View")
            ]),
            new("AgentBonusReport", [
                new("View")
            ]),
            new("AllAgentRebateReport", [
                new("View")
            ]),
            new("VipReport", [
                new("View")
            ]),
            new("BalanceChangeReport", [
                new("View")
            ]),
            new("GameProviders", [
                new("View")
            ]),
            new("GameProviderReport", [
                new("View")
            ]),
            new("WinlossReport", [
                new("View")
            ]),
            new("AgentDividend", [
                new("View"),
                new("Update")
            ])
        ]),
        new("LicenseeReport", [
            new("MarketReport", [
                new("View")
            ])
        ]),
        new("ResellerReport", [
            new("MarketReport", [
                new("View")
            ]),
            new("BalanceAdjustReport", [
                new("View")
            ])
        ]),
        new("Merchant", [
            new("Resellers", [
                new("View"),
                new("Update")
            ]),
            new("Licensees", [
                new("View"),
                new("Update")
            ]),
            new("Brands", [
                new("View"),
                new("Update")
            ]),
            new("PlatformCredit", [
                new("View"),
                new("Update")
            ]),
            new("PlatformAccountFund", [
                new("View"),
                new("Update")
            ]),
            new("Maintenance", [
                new("View"),
                new("Update")
            ])
        ]),
        new("FundManagement", [
            new("Deposit", [
                new("View"),
                new("Update")
            ]),
            new("DepositHistory", [
                new("View"),
                new("Update")
            ]),
            new("Withdraw", [
                new("View"),
                new("Update"),
                new("Reject")
            ]),
            new("WithdrawHistory", [
                new("View"),
                new("Update"),
                new("Reject")
            ])
        ]),
        new("Marketing", [
            new("PlayerDeposit", [
                new("View")
            ]),
            new("MarketingReport", [
                new("View")
            ])
        ]),
        new("System", [
            new("Admins", [
                new("View"),
                new("Create"),
                new("Update")
            ]),
            new("Roles", [
                new("View"),
                new("Create"),
                new("Update"),
                new("Delete"),
                new("Copy")
            ]),
            new("Departments", [
                new("View"),
                new("Create"),
                new("Update"),
                new("Delete")
            ]),
            new("BrandPayments", [
                new("View"),
                new("Update")
            ])
        ]),
        new("SystemAdmin", [
            new("GameProviderRound", [
                new("View"),
                new("Update"),
                new("Export"),
            ]),
            new("GameRound", [
                new("View"),
                new("ViewGameAction"),
                new("Update")
            ]),
            new("ResettleGameRound", [
                new("View"),
                new("ViewGameAction"),
                new("Update")
            ]),
            new("GameProviders", [
                new("View"),
                new("Update")
            ]),
            new("GameProviderReport", [
                new("View"),
                new("Update")
            ]),
            new("BrandPayments", [
                new("View"),
                new("Update")
            ]),
            new("Sms", [
                new("View"),
                new("Update")
            ]),
            new("PlatformGameProvider", [
                new("View")
            ]),
            new("Language", [
                new("View"),
                new("Update")
            ]),
            new("Currency", [
                new("View"),
                new("Update")
            ]),
            new("BetLimit", [
                new("View"),
                new("Update")
            ]),
            new("Settings", [
                new("View"),
                new("Update")
            ])
        ]),
        new("Log", [
            new("AdminLog", [
                new("View")
            ]),
            new("ApiLog", [
                new("View")
            ]),
            new("Log", [
                new("View")
            ])
        ])
    ];

    private async Task GenerateSettingsAsync()
    {
        var options = new JsonSerializerOptions { WriteIndented = false };

        var commonSettings = new[]
        {
            CreateSetting(SettingConsts.Menus,
                _jsonSerializationProvider.SerializeToString(GetMenuSettings(), options),
                "For menus used"),
            CreateSetting(SettingConsts.SuperLicenseeCodes,
                _jsonSerializationProvider.SerializeToString(new[]
                {
                    "TGS"
                }, options),
                "Super Licensee Codes"),
            CreateSetting(SettingConsts.ArrearsEmail,
                _jsonSerializationProvider.SerializeToString(GetArrearsEmail(), options),
                "Arrears Email")
        };

        var gameProviderSettings = _gameProviders.Select(gp =>
        {
            var configuration = gp.GetConfiguration();
            var key = SettingConsts.GameProviderConfigurations.Template.Args(gp.Code);
            var value = _jsonSerializationProvider.SerializeToString(configuration,
                configuration.GetType(),
                options);

            return CreateSetting(key, value, $"JSON based configuration of {gp.Code}");
        }).ToArray();

        var settings = commonSettings.Concat(gameProviderSettings).ToArray();

        await _repository.Settings.AddRangeAsync(settings);
        _ = await _repository.SaveChangesAsync();
    }
}
