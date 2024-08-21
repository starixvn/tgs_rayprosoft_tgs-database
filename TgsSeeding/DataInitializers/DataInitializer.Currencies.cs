// ReSharper disable InconsistentNaming

namespace TGS.Core.DataServices.Tgs.DataInitializers;

public partial class DataInitializer
{
    internal interface ICurrency : ICodeMapper { }

    internal record CNYCurrency(string? externalCode = null)
        : BaseCodeMapper("CNY", externalCode), ICurrency { }

    internal record EURCurrency(string? externalCode = null)
        : BaseCodeMapper("EUR", externalCode), ICurrency { }

    internal record GBPCurrency(string? externalCode = null)
        : BaseCodeMapper("GBP", externalCode), ICurrency { }

    internal record IDRCurrency(string? externalCode = null)
        : BaseCodeMapper("IDR", externalCode), ICurrency { }

    internal record IDR1000Currency(string? externalCode = null)
        : BaseCodeMapper("IDR_1000", externalCode), ICurrency { }

    internal record INRCurrency(string? externalCode = null)
        : BaseCodeMapper("INR", externalCode), ICurrency { }

    internal record JPYCurrency(string? externalCode = null)
        : BaseCodeMapper("JPY", externalCode), ICurrency { }

    internal record KRWCurrency(string? externalCode = null)
        : BaseCodeMapper("KRW", externalCode), ICurrency { }

    internal record MYRCurrency(string? externalCode = null)
        : BaseCodeMapper("MYR", externalCode), ICurrency { }

    internal record SGDCurrency(string? externalCode = null)
        : BaseCodeMapper("SGD", externalCode), ICurrency { }

    internal record THBCurrency(string? externalCode = null)
        : BaseCodeMapper("THB", externalCode), ICurrency { }

    internal record USDCurrency(string? externalCode = null)
        : BaseCodeMapper("USD", externalCode), ICurrency { }

    internal record VNDCurrency(string? externalCode = null)
        : BaseCodeMapper("VND", externalCode), ICurrency { }

    internal record VND1000Currency(string? externalCode = null)
        : BaseCodeMapper("VND_1000", externalCode), ICurrency { }

    internal record HKDCurrency(string? externalCode = null)
        : BaseCodeMapper("HKD", externalCode), ICurrency { }

    internal record PHPCurrency(string? externalCode = null)
        : BaseCodeMapper("PHP", externalCode), ICurrency { }
}
