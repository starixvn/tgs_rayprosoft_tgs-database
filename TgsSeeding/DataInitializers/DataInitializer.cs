using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tgs.Core.Infrastructures.Security;
using Tgs.Core.Infrastructures.Utility;
using TGS.Core.DataServices.Base.DataInitializers;
using TGS.Core.DataServices.Tgs.Models;
using TGS.Core.Infrastructures.Extensions;
using TGS.Core.Infrastructures.Json;
using TGS.Core.Models.Enums;
using static TGS.Core.Models.Enums.GameActionType;

namespace TGS.Core.DataServices.Tgs.DataInitializers;

[ExcludeFromCodeCoverage]
public partial class DataInitializer : BaseDataInitializer
{
    private const string AdminUsername = "admin.enabled";
    private static readonly IRole _GpiBrandRole = new GpiBrandRole();
    private static readonly DateTimeOffset _Now = DateTimeOffset.UtcNow;

    private static readonly IList<IReseller> _Resellers = new IReseller[]
    {
        new TgsReseller()
    };

    private readonly Dictionary<string, Brand> _brandCreated = new();

    private readonly CurrencyDefined[] _currencies =
    {
        new("CNY", "Yuan", "元", "¥"),
        new("EUR", "Euro", "Euro", "€"),
        new("GBP", "Pound Sterling", "Pound Sterling", "£"),
        new("IDR", "Indonesian rupiah", "rupiah Indonesia", "Rp"),
        new("IDR_1000", "Indonesian rupiah", "rupiah Indonesia", "Rp"),
        new("INR", "Indian Rupee", "भारतीय रुपये", "₹"),
        new("JPY", "Japanese Yen", "円", "¥"),
        new("KRW", "Korean won", "Korean won", "₩"),
        new("MYR", "Malaysian Ringgit", "Malaysian Ringgit", "RM"),
        new("SGD", "Singapore Dollar", "Singapore Dollar", "$"),
        new("THB", "Thai Baht", "บาท", "฿"),
        new("USD", "United States Dollar", "United States Dollar", "$"),
        new("VND", "Vietnamese Dong", "đồng", "₫"),
        new("VND_1000", "Vietnamese Dong", "đồng", "₫"),
        new("HKD", "Hong Kong Dollars", "元", "HK$"),
        new("PHP", "Philippine Peso", "披索", "₱")
    };

    private readonly IList<IGameProvider> _gameProviders;

    private readonly Dictionary<string, GameProvider> _gameProvidersCreated = new();

    private readonly IJsonSerializationProvider _jsonSerializationProvider;
    private readonly ITgsRepository _repository;

    private readonly IRole[] _roles =
    {
        new AdminRole(),
        new ResellerAdminRole(),
        new LicenseeAdminRole(),
        new TgsBrandRole(),
        _GpiBrandRole
    };

    private BetLimit[]? _betLimits;
    private VipLevel[]? _vipLevels;

    public DataInitializer(ITgsRepository repository)
    {
        _repository = repository;

        _jsonSerializationProvider = new JsonSerializationProvider();

        _gameProviders = new IGameProvider[]
        {
            new SBOGameProvider(),
            new HabaneroGameProvider(),
            new PragmaticPlayGameProvider(),
            new AsiaGamingGameProvider(),
            new SabaGameProvider(),
            new KYGameProvider(),
            new VRGameProvider(),
            new IMESportsGameProvider(),
            new BigGamingGameProvider(),
            new JDBGameProvider(),
            new SexyGamingGameProvider(),
            new SkywindGameProvider(),
            new AllBetGameProvider(),
            new EvolutionGameProvider(),
            new WGSportsGameProvider(),
            new WGHorseGameProvider(),
            new WMCasinoGameProvider(),
            new TCGGameProvider(),
            new Card365GameProvider(),
            new LYGameProvider(),
            new BetConstructProvider(),
            new AviaGameProvider(),
            new JiliGameProvider(),
            new TFGameProvider(),
            new DreamGameGameProvider(),
            new JokerGameProvider(),
            new PragmaticPlayTransferGameProvider(),
            new AWC_AELOTTOGameProvider(),
            new AWC_AWSGameProvider(),
            new AWC_COCKFIGHTGameProvider(),
            new AWC_FACAIGameProvider(),
            new AWC_FSGameProvider(),
            new AWC_KMGameProvider(),
            new AWC_LUDOGameProvider(),
            new AWC_PGSGameProvider(),
            new AWC_RCBGameProvider(),
            new AWC_SGGameProvider(),
            new AWC_SPADEGameProvider(),
            new AWC_VENUSGameProvider(),
            new AWC_YLGameProvider(),
            new JiliTransferGameProvider(),
            new WMCasinoTransferGameProvider()
        };
    }

    public override async Task SetInitialDataAsync()
    {
        if (_repository.Currencies.Any())
        {
            return;
        }

        var logBuilder = new StringBuilder();

        var timer = new Stopwatch();
        timer.Start();

        await LogSeedingTimeAsync(GenerateCurrenciesAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateLanguagesAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateBetLimitsAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateGameProvidersAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateResellersWithDescendantsAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateVipLevelsAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateSettingsAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateLocalizedStringsAsync, logBuilder);
        await LogSeedingTimeAsync(GeneratePaymentAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateDepartmentsAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateRolesAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateSportTypesAndMarketTypesAsync, logBuilder);
        await LogSeedingTimeAsync(GeneratePromotionsAsync, logBuilder);
        await LogSeedingTimeAsync(GenerateApplePayInitialDataAsync, logBuilder);
        await LogSeedingTimeAsync(GeneratePlatformCreditsAsync, logBuilder);

        timer.Stop();

        _ = logBuilder.AppendLine($"Total Time was {timer.ElapsedMilliseconds} ms");
        Console.WriteLine(logBuilder.ToString());
    }

    private static GameProvider CreateGameProvider(IGameProvider gameProvider)
    {
        var gp = new GameProvider
        {
            Id = gameProvider.Id,
            Name = gameProvider.Name,
            Code = gameProvider.Code,
            UniqueId = gameProvider.UniqueId,
            Description = gameProvider.Name,
            AutoCloseRound = gameProvider.AutoClosedRound,
            Status = Status.Active,
            SupportTestPlayer = gameProvider.SupportTestPlayer,
            AllowKickPlayer = gameProvider.AllowKickPlayer,
            TransferWallet = gameProvider.TransferWallet,
            CreatedOn = _Now,
            UpdatedOn = _Now,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername,
            Currencies =
                gameProvider.Currencies.Select(curr =>
                    new GameProviderCurrency
                    {
                        GameProviderId = gameProvider.Id,
                        CurrencyCode = curr.Code,
                        GameProviderCurrencyCode = curr.ExternalCode
                    }).ToHashSet(),
            Languages = gameProvider.Languages.Select(lang =>
                new GameProviderLanguage
                {
                    GameProviderId = gameProvider.Id,
                    CultureCode = lang.Code,
                    GameProviderCultureCode = lang.ExternalCode
                }).ToHashSet()
        };

        gp.GameProviderConfigurations = gameProvider.GameProviderConfigurations.Select((gpc, idx) =>
            new GameProviderConfiguration
            {
                Id = gpc.Id,
                Name = gpc.Name,
                ClientId = gpc.ClientId,
                SecretKey = gpc.SecretKey,
                DesktopEndpoint = gpc.DesktopEndpoint,
                MobileEndpoint = gpc.MobileEndpoint,
                Description = gp.Name,
                GameProviderId = gp.Id,
                CreatedOn = _Now,
                UpdatedOn = _Now,
                CreatedByUsername = AdminUsername,
                UpdatedByUsername = AdminUsername,
                ConfigurationData = gpc.ConfigurationData,
                IsDefault = idx == 0
            }).ToHashSet();

        gp.SubGameProviders = gameProvider.SubGameProviders.Select(sgp => new Models.SubGameProvider
        {
            Code = sgp.Code,
            Name = sgp.Name,
            CreatedOn = _Now,
            UpdatedOn = _Now,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername
        }).ToHashSet();

        gp.Games = gameProvider.Games!.Select((g, idx) => new Models.Game
        {
            Id = int.Parse($"{gp.UniqueId}{idx + 1:00000}"),
            Name = g.Name,
            ExternalId = g.ExternalId,
            Code = g.Code,
            EndpointPath = g.EndpointPath,
            RuleUrl = g.GameRuleUrl,
            Type = g.GameTypeCode,
            Description = g.Description,
            Status = GameStatus.Active,
            GameProvider = gp,
            GameProviderId = gp.Id,
            PlatformType = g.PlatformType,
            HasTurnoverOnTieBet = g.HasTurnoverOnTieBet,
            SubGame = g.SubGame,
            AvailableToBrand = g.AvailableToBrand,
            Html5 = g.Html5,
            CreatedOn = _Now,
            UpdatedOn = _Now,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername,
            AvailableCurrencies = g.AvailableCurrencies,
            SubGameProviderCode = g.SubGameProviderCode
        }).ToHashSet();

        gp.BetLimits = gameProvider.BetLimits.Select(b => new Models.GameProviderBetLimit
        {
            Id = b.Id,
            GameProviderId = gp.Id,
            CurrencyCode = b.CurrencyCode,
            MinBet = b.MinBet,
            MaxBet = b.MaxBet,
            MaxBetPerMatch = b.MaxBetPerMatch,
            ExternalSetting = b.ExternalSetting
        }).ToHashSet();

        return gp;
    }

    private static IEnumerable<LocalizedString> GetGameLocalizedStrings(Models.Game g, string cultureCode) =>
        new LocalizedString[]
        {
            new()
            {
                Context = "Game.Name",
                Key = g.Id.ToString(),
                CultureCode = cultureCode,
                Translation = g.Name
            },
            new()
            {
                Context = "Game.Description",
                Key = g.Id.ToString(),
                CultureCode = cultureCode,
                Translation = g.Description
            }
        };

    private static IEnumerable<LocalizedString>
        GetGameProviderLocalizedStrings(GameProvider gp, string cultureCode) =>
        new LocalizedString[]
        {
            new()
            {
                Context = "GameProvider.Name",
                Key = gp.Id.ToString(),
                CultureCode = cultureCode,
                Translation = gp.Name
            },
            new()
            {
                Context = "GameProvider.Description",
                Key = gp.Id.ToString(),
                CultureCode = cultureCode,
                Translation = gp.Description
            }
        };

    private static (DateTimeOffset, DateTimeOffset, DateTimeOffset, DateTimeOffset) GetInterval(
        SettlementIntervalType type, DateTimeOffset startDate, int? dayOfMonth, DateTimeOffset currentFromDate)
    {
        switch (type)
        {
            case SettlementIntervalType.Daily:
                return (startDate, startDate, startDate.AddDays(1), startDate.AddDays(1));

            case SettlementIntervalType.Weekly:
                return (startDate,
                    DateGenerator.GetLastDayOfWeek(startDate),
                    DateGenerator.GetFirstDayOfWeek(startDate.AddDays(7)),
                    DateGenerator.GetLastDayOfWeek(startDate.AddDays(7)));

            case SettlementIntervalType.Monthly:
                if (dayOfMonth == null)
                {
                    return (startDate,
                        DateGenerator.GetLastDayOfMonth(startDate),
                        DateGenerator.GetFirstDayOfMonth(startDate.AddMonths(1)),
                        DateGenerator.GetLastDayOfMonth(startDate.AddMonths(1)));
                }

                if (startDate.Day <= dayOfMonth)
                {
                    return (currentFromDate,
                        startDate,
                        startDate.AddDays(1),
                        DateGenerator.GetSpecifyDayOfMonth(startDate, dayOfMonth.Value!));
                }

                return (currentFromDate,
                    startDate,
                    startDate.AddDays(1),
                    DateGenerator.GetSpecifyDayOfMonth(startDate.AddMonths(1),
                        dayOfMonth.Value!));

            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    private Brand CreateBrand(IReseller reseller, ILicensee licensee, IBrand brand)
    {
        var gameProviderCodes = IntersectGameProviderCodes(reseller.GameProviders, licensee.GameProviders);
        gameProviderCodes = IntersectGameProviderCodes(gameProviderCodes, brand.GameProviders);
        var gameProviders = GetGameProviders(gameProviderCodes);
        var gameProviderBetLimits = gameProviders.SelectMany(gp => gp.BetLimits).ToArray();

        var brandGameProviders = gameProviders.Select(gp =>
        {
            var brandGameProviderId = Guid.NewGuid();

            return new BrandGameProvider
            {
                Id = brandGameProviderId,
                GameProviderId = gp.Id,
                GameProvider = gp,
                BrandId = brand.Id,
                GameProviderConfigurationId = gp.GameProviderConfigurations.Where(gpc => gpc.IsDefault)
                    .Select(gpc => gpc.Id).FirstOrDefault(),
                DefaultLanguageCode = "en-US",
                DesktopQueryString = string.Empty,
                MobileQueryString = string.Empty,
                Schedules = new BrandGameProviderSchedule[]
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        BrandGameProviderId = brandGameProviderId,
                        From = DateTimeOffset.UtcNow,
                        To = DateTimeOffset.UtcNow.AddDays(7),
                        DayOfWeek = DayOfWeek.Monday,
                        IsDefault = true
                    }
                }.ToHashSet()
            };
        }).ToArray();

        var brandCurrencies = brand.Currencies.Select(b => b.Code).ToArray();

        var games = (from game in gameProviders.SelectMany(gp => gp.Games)
                     let availableCurrencies =
                         game.AvailableCurrencies.Split(',', StringSplitOptions.RemoveEmptyEntries)
                     where game.AvailableToBrand &&
                           (availableCurrencies.Length == 0 ||
                            availableCurrencies.Any(curr => brandCurrencies.Contains(curr)))
                     select game)
            .Select((g, idx) => new BrandGame
            {
                Id = Guid.NewGuid(),
                BrandId = brand.Id,
                GameId = g.Id,
                Status = GameStatus.Active,
                Tag = GetGameTag(idx),
                Rebate = true,
                EffectiveBettingPercentage = 100,
                DisplayOrder = 99
            }).ToHashSet();

        var betLimits = _betLimits
            ?.Where(bl => brandCurrencies.Contains(bl.CurrencyCode))
            .Select(bl => new BrandBetLimit
            {
                BrandId = brand.Id,
                BetLimitId = bl.Id,
                BetLimit = bl,
                IsDefault = _betLimits.Where(l => l.CurrencyCode == bl.CurrencyCode).Min(l => l.MinBet) == bl.MinBet
            }).ToHashSet();

        var timeSpan = new TimeSpan(8, 0, 0);

        var now = new DateTimeOffset(DateTimeOffset.Now.Year,
            DateTimeOffset.Now.Month,
            DateTimeOffset.Now.Day,
            0,
            0,
            0,
            timeSpan);

        var (currentFromDate, currentToDate, nextFromDate, nextToDate) =
            GetInterval(brand.Type, now, brand.SettlementDay, now);

        return new()
        {
            Id = brand.Id,
            Code = brand.Code,
            Name = brand.Name,
            OperationalEmail = brand.OperationalEmail,
            Status = BrandStatus.Active,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername,
            CreatedOn = _Now,
            UpdatedOn = _Now,
            LicenseeId = licensee.Id,
            TimeZoneId = brand.TimeZoneId,
            Description = string.Empty,
            ClientId = brand.ClientId,
            SecretKey = brand.SecretKey,
            ApiKey = brand.ApiKey,
            SettlementIntervalType = brand.Type,
            PreviousSettlementFrom = currentFromDate,
            PreviousSettlementTo = currentToDate,
            CurrentSettlementFrom = currentFromDate,
            CurrentSettlementTo = currentToDate,
            NextSettlementFrom = nextFromDate,
            NextSettlementTo = nextToDate,
            AutoSentAgentBonus = true,
            AutoSentPlayerBonus = true,
            Currencies =
                brand.Currencies.Select(curr => new BrandCurrency
                {
                    BrandId = brand.Id,
                    CurrencyCode = curr.Code,
                    BrandCurrencyCode = curr.ExternalCode
                }).ToHashSet(),
            Languages = brand.Languages.Select(lang => new BrandLanguage
            {
                BrandId = brand.Id,
                CultureCode = lang.Code,
                BrandCultureCode = lang.ExternalCode
            }).ToHashSet(),
            GameProviders = brandGameProviders.ToHashSet(),
            Games = games,
            BetLimits = betLimits,
            BrandGroups = brand.Groups.Select(name =>
            {
                var brandGroupId = Guid.NewGuid();

                return new BrandGroup
                {
                    Id = brandGroupId,
                    BrandId = brand.Id,
                    Name = name,
                    CreatedByUsername = AdminUsername,
                    UpdatedByUsername = AdminUsername,
                    CreatedOn = _Now,
                    UpdatedOn = _Now,
                    Description = string.Empty,
                    BrandGames =
                        games.Select(g => new BrandGroupGame
                        {
                            BrandGroupId = brandGroupId,
                            BrandGameId = g.Id
                        })
                            .ToHashSet(),
                    BrandGroupBetLimits = betLimits?.Select(b =>
                    {
                        var brandGroupBetLimitId = Guid.NewGuid();

                        return new BrandGroupBetLimit
                        {
                            Id = brandGroupBetLimitId,
                            BrandGroupId = brandGroupId,
                            BetLimitId = b.BetLimitId,
                            GameProviderBetLimits = brandGameProviders.Where(g =>
                                g.GameProvider.BetLimits
                                    .Any(gb =>
                                        gb.CurrencyCode == b.BetLimit.CurrencyCode &&
                                        b.BetLimit.MinBet <= gb.MinBet &&
                                        b.BetLimit.MaxBet >= gb.MaxBet)).Select(g =>
                            {
                                var gpBetLimits = g.GameProvider.BetLimits
                                    .OrderBy(gb => gb.MinBet).ToArray();

                                return gpBetLimits.Length == 0
                                    ? null
                                    : new BrandGroupGameProviderBetLimit
                                    {
                                        BrandGroupBetLimitId = brandGroupBetLimitId,
                                        GameProviderBetLimitId = gpBetLimits.First().Id
                                    };
                            }).ToHashSet()
                        };
                    }).ToHashSet()
                };
            }).ToHashSet()
        };

        static GameTag GetGameTag(int index) =>
            (index % 3) switch
            {
                0 => GameTag.New,
                1 => GameTag.New | GameTag.Recommend,
                2 => GameTag.New | GameTag.Recommend | GameTag.Hot,
                _ => GameTag.None
            };

        static string[] IntersectGameProviderCodes(string[] parents, string[] children) =>
            parents.Length == 0 ? children :
            children.Length == 0 ? parents : parents.Intersect(children).ToArray();
    }

    private Licensee CreateLicenseeWithBrands(IReseller reseller, ILicensee licensee)
    {
        var gameProviderCodes = reseller.GameProviders.Length == 0
            ? licensee.GameProviders
            : reseller.GameProviders.Intersect(licensee.GameProviders).ToArray();

        var gameProviders = GetGameProviders(gameProviderCodes);

        var licenseeCurrencies = licensee.Currencies.Select(c => c.Code).ToArray();

        return new()
        {
            Id = licensee.Id,
            Code = licensee.Code,
            Name = licensee.Name,
            OperationalEmail = licensee.OperationalEmail,
            Status = Status.Active,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername,
            CreatedOn = _Now,
            UpdatedOn = _Now,
            ResellerId = reseller.Id,
            Description = string.Empty,
            Currencies =
                licensee.Currencies.Select(curr =>
                    new LicenseeCurrency
                    {
                        LicenseeId = licensee.Id,
                        CurrencyCode = curr.Code
                    }).ToHashSet(),
            Languages =
                licensee.Languages.Select(lang =>
                    new LicenseeLanguage
                    {
                        LicenseeId = licensee.Id,
                        CultureCode = lang.Code
                    }).ToHashSet(),
            GameProviders =
                gameProviders.Select(gp =>
                    new LicenseeGameProvider
                    {
                        GameProviderId = gp.Id,
                        LicenseeId = licensee.Id
                    }).ToHashSet(),
            Brands = licensee.Brands.Select(b => CreateBrand(reseller, licensee, b)).ToHashSet(),
            BetLimits = _betLimits
                ?.Where(lbl => licenseeCurrencies.Contains(lbl.CurrencyCode))
                .Select(lbl => new LicenseeBetLimit
                {
                    LicenseeId = licensee.Id,
                    BetLimitId = lbl.Id
                })
                .ToHashSet()
        };
    }

    private Reseller CreateResellerWithLicensees(IReseller reseller)
    {
        var gameProviders = GetGameProviders(reseller.GameProviders);

        return new()
        {
            Id = reseller.Id,
            Code = reseller.Code,
            Name = reseller.Name,
            OperationalEmail = reseller.OperationalEmail,
            Description = string.Empty,
            BusinessType = reseller.BusinessType,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername,
            CreatedOn = _Now,
            UpdatedOn = _Now,
            Currencies =
                reseller.Currencies.Select(curr =>
                    new ResellerCurrency
                    {
                        ResellerId = reseller.Id,
                        CurrencyCode = curr.Code
                    }).ToHashSet(),
            Languages =
                reseller.Languages.Select(lang =>
                    new ResellerLanguage
                    {
                        ResellerId = reseller.Id,
                        CultureCode = lang.Code
                    }).ToHashSet(),
            Licensees = reseller.Licensees.Select(l => CreateLicenseeWithBrands(reseller, l)).ToHashSet(),
            GameProviders =
                gameProviders.Select(gp =>
                    new ResellerGameProvider
                    {
                        GameProviderId = gp.Id,
                        ResellerId = reseller.Id
                    }).ToHashSet(),
            BetLimits = _betLimits?.Select(bl => new ResellerBetLimit
            {
                ResellerId = reseller.Id,
                BetLimitId = bl.Id
            })
                .ToHashSet()
        };
    }

    private Role[] CreateRoleWithMenus(IRole[] roles) =>
        roles.Select(role => new Role
        {
            Id = role.Id,
            IsRoot = role.IsRoot,
            Name = role.Name,
            DisplayName = role.Name,
            ResellerId = role.ResellerId,
            LicenseeId = role.LicenseeId,
            BrandId = role.BrandId,
            Description = role.Description,
            Status = RoleStatus.Enabled,
            CreatedOn = DateTimeOffset.Now,
            UpdatedOn = DateTimeOffset.Now,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername,
            MenuSetting = _jsonSerializationProvider.SerializeToString(GetMenuSettings()),
            RoleType = role.RoleType
        }).ToArray();

    private async Task GenerateBetLimitsAsync()
    {
        BetLimitDefined[] limits =
        {
            new("CNY", 1, 200, 1000),
            new("CNY", 10, 300, 1000),
            new("EUR", 1, 200, 1000),
            new("GBP", 1, 200, 1000),
            new("IDR", 1000, 200000, 1000000),
            new("IDR_1000", 1, 200, 1000),
            new("INR", 1, 200, 1000),
            new("JPY", 1, 200, 1000),
            new("KRW", 1, 200, 1000),
            new("MYR", 1, 200, 1000),
            new("SGD", 1, 200, 1000),
            new("THB", 1, 200, 1000),
            new("USD", 1, 200, 1000),
            new("VND", 1000, 200000, 1000000),
            new("VND_1000", 1, 200, 1000),
            new("HKD", 1, 200, 1000),
        };

        _betLimits = limits.Select(b => new BetLimit
        {
            CurrencyCode = b.CurrencyCode,
            MinBet = b.MinBet,
            MaxBet = b.MaxBet,
            MaxBetPerMatch = b.MaxBetPerMatch,
            CreatedOn = _Now,
            UpdatedOn = _Now,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername
        }).ToArray();

        await _repository.BetLimits.AddRangeAsync(_betLimits);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GenerateCurrenciesAsync()
    {
        var currencies = _currencies
            .Select(c => new Currency
            {
                Code = c.Code,
                Name = c.Name,
                NativeName = c.NativeName,
                Symbol = c.Symbol,
                CreatedByUsername = AdminUsername,
                UpdatedByUsername = AdminUsername,
                CreatedOn = _Now,
                UpdatedOn = _Now
            }).ToArray();

        await _repository.Currencies.AddRangeAsync(currencies);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GenerateGameProvidersAsync()
    {
        foreach (var gp in _gameProviders)
        {
            var gameProvider = CreateGameProvider(gp);
            _gameProvidersCreated.Add(gp.Code, gameProvider);
        }

        var gameProviders = _gameProvidersCreated.Values.ToArray();

        await _repository.GameProviders.AddRangeAsync(gameProviders);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GenerateLanguagesAsync()
    {
        var languages = new[]
            {
                new
                {
                    CultureCode = "en-US",
                    LanguageCode = "en",
                    Name = "English",
                    LocalizedName = "English"
                },
                new
                {
                    CultureCode = "id-ID",
                    LanguageCode = "id",
                    Name = "Indonesian",
                    LocalizedName = "bahasa Indonesia"
                },
                new
                {
                    CultureCode = "ja-JP",
                    LanguageCode = "ja",
                    Name = "Japanese",
                    LocalizedName = "日本語"
                },
                new
                {
                    CultureCode = "ko-KR",
                    LanguageCode = "ko",
                    Name = "Korean",
                    LocalizedName = "한국어 / 조선말"
                },
                new
                {
                    CultureCode = "th-TH",
                    LanguageCode = "th",
                    Name = "Thai",
                    LocalizedName = "ภาษาไทย"
                },
                new
                {
                    CultureCode = "vi-VN",
                    LanguageCode = "vi",
                    Name = "Vietnamese",
                    LocalizedName = "ngôn ngữ tiếng Việt"
                },
                new
                {
                    CultureCode = "zh-CN",
                    LanguageCode = "cn",
                    Name = "Simplified Chinese",
                    LocalizedName = "简体中文"
                },
                new
                {
                    CultureCode = "zh-TW",
                    LanguageCode = "zh",
                    Name = "Traditional Chinese",
                    LocalizedName = " 繁體中文"
                }
            }
            .Select(p => new Language
            {
                CultureCode = p.CultureCode,
                LanguageCode = p.LanguageCode,
                Name = p.Name,
                LocalizedName = p.LocalizedName,
                CreatedByUsername = AdminUsername,
                UpdatedByUsername = AdminUsername,
                CreatedOn = _Now,
                UpdatedOn = _Now
            }).ToArray();

        await _repository.Languages.AddRangeAsync(languages);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GenerateLocalizedStringsAsync()
    {
        var localizedStrings = new List<LocalizedString>();

        foreach (var gp in _gameProvidersCreated.Values)
            foreach (var cultureCode in gp.Languages.Select(l => l.CultureCode))
            {
                var gpData = GetGameProviderLocalizedStrings(gp, cultureCode);
                localizedStrings.AddRange(gpData);

                foreach (var g in gp.Games)
                {
                    var gameData = GetGameLocalizedStrings(g, cultureCode);
                    localizedStrings.AddRange(gameData);
                }
            }

        await _repository.LocalizedStrings.AddRangeAsync(localizedStrings);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GeneratePlatformCreditsAsync()
    {
        var platformCredits = _brandCreated.Select(x => new PlatformCredit
        {
            BrandId = x.Value.Id,
            Credit = 1000,
            Balance = 1000,
            CreatedOn = _Now,
            UpdatedOn = _Now,
            CreatedByUsername = AdminUsername,
            UpdatedByUsername = AdminUsername
        });

        await _repository.PlatformCredits.AddRangeAsync(platformCredits);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GeneratePromotionsAsync()
    {
        var now = new DateTimeOffset(DateTimeOffset.Now.Year,
            DateTimeOffset.Now.Month,
            DateTimeOffset.Now.Day,
            0,
            0,
            0,
            new(8, 0, 0));

        var promotions = _brandCreated.Select(x =>
        {
            var promotionId = Guid.NewGuid();

            return new Promotion
            {
                Id = promotionId,
                Name = $"{x.Value.Name}_發發發流流流長江流水向東流",
                From = now,
                To = now.AddDays(7),
                Status = PromotionStatus.Enabled,
                BrandId = x.Value.Id,
                PromotionType = "TurnoverRebate",
                BonusAmountLimit = 1000000,
                Unlimited = false,
                PromotionGameProviders =
                    _gameProviders.Select(g =>
                            new PromotionGameProvider
                            {
                                PromotionId = promotionId,
                                GameProviderId = g.Id
                            })
                        .ToHashSet(),
                PromotionVipLevels =
                    x.Value.VipLevels.Select(v =>
                            new PromotionVipLevel
                            {
                                PromotionId = promotionId,
                                VipLevelId = v.Id,
                                Level = v.Level
                            })
                        .ToHashSet(),
                PromotionParticipants =
                    x.Value.Players.Select(p =>
                            new PromotionParticipant
                            {
                                PlayerCode = p.PlayerCode,
                                PromotionId = promotionId,
                                CreatedOn = now
                            })
                        .ToHashSet(),
                CreatedOn = DateTimeOffset.Now,
                UpdatedOn = DateTimeOffset.Now
            };
        });

        await _repository.Promotions.AddRangeAsync(promotions);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GenerateResellersWithDescendantsAsync()
    {
        // resellers
        var resellers = _Resellers.Select(CreateResellerWithLicensees).ToArray();

        await _repository.Resellers.AddRangeAsync(resellers);

        // licensees
        var licensees = resellers.SelectMany(r => r.Licensees).ToArray();
        await _repository.Licensees.AddRangeAsync(licensees);

        // brands
        var brands = licensees.SelectMany(l => l.Brands).ToArray();

        foreach (var b in brands)
        {
            _brandCreated.Add(b.Code, b);
        }

        await _repository.Brands.AddRangeAsync(brands);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GenerateRolesAsync()
    {
        var roles = CreateRoleWithMenus(_roles);

        await _repository.Roles.AddRangeAsync(roles);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GenerateSportTypesAndMarketTypesAsync()
    {
        var sports = _gameProviders.Where(g => g.SportTypes.Count > 0)
            .SelectMany(g => g.SportTypes.Select(s => new SportType
            {
                Id = Guid.NewGuid(),
                GameProviderId = g.Id,
                Code = s.Key,
                ExternalId = s.Value
            })).ToArray();

        var markets = _gameProviders.Where(g => g.MarketTypes.Count > 0)
            .SelectMany(g => g.MarketTypes.Select(s => new MarketType
            {
                Id = Guid.NewGuid(),
                GameProviderId = g.Id,
                Code = s.Key,
                ExternalId = s.Value
            })).ToArray();

        var relation = (from s in sports
                        let m = markets.First(m => m.GameProviderId == s.GameProviderId)
                        select new SportMarketType
                        {
                            Id = Guid.NewGuid(),
                            SportTypeId = s.Id,
                            MarketTypeId = m.Id
                        })
            .ToArray();

        await _repository.SportTypes.AddRangeAsync(sports);
        await _repository.MarketTypes.AddRangeAsync(markets);
        await _repository.SportMarketTypes.AddRangeAsync(relation);
        _ = await _repository.SaveChangesAsync();
    }

    private async Task GenerateVipLevelsAsync()
    {
        _vipLevels = _Resellers.SelectMany(x => x.Licensees.SelectMany(l => l.Brands))
            .Distinct()
            .Select(brand => new VipLevel
            {
                Id = Guid.NewGuid(),
                BrandId = brand.Id,
                Level = 1,
                LiveDealerRebatePercentage = 1,
                LotteryRebatePercentage = 2,
                CardGameRebatePercentage = 3,
                SlotRebatePercentage = 4,
                SportsRebatePercentage = 5,
                VirtualSportsRebatePercentage = 6,
                CreatedByUsername = AdminUsername,
                UpdatedByUsername = AdminUsername,
                CreatedOn = _Now,
                UpdatedOn = _Now
            })
            .ToArray();

        await _repository.VipLevels.AddRangeAsync(_vipLevels);
        _ = await _repository.SaveChangesAsync();
    }

    private GameProvider[] GetGameProviders(IReadOnlyCollection<string> gameProviderCodes) =>
        gameProviderCodes.Count == 0
            ? _gameProvidersCreated.Values.ToArray()
            : gameProviderCodes
                .Select(code => _gameProvidersCreated[code])
                .ToArray();
}

internal class Generator
{
    private static readonly Random _Random = new();

    public static string RandomIntString(int length)
    {
        const string chars = "0123456789";

        return new(Enumerable.Repeat(chars, length)
            .Select(s => s[_Random.Next(s.Length)]).ToArray());
    }

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuwxyz0123456789";

        return new(Enumerable.Repeat(chars, length)
            .Select(s => s[_Random.Next(s.Length)]).ToArray());
    }
}
