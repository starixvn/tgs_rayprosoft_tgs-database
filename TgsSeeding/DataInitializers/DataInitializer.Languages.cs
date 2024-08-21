namespace TGS.Core.DataServices.Tgs.DataInitializers;

public partial class DataInitializer
{
    internal interface ILanguage : ICodeMapper { }

    internal record USLanguage(string? externalCode = null)
        : BaseCodeMapper("en-US", externalCode), ILanguage { }

    internal record IDLanguage(string? externalCode = null)
        : BaseCodeMapper("id-ID", externalCode), ILanguage { }

    internal record JPLanguage(string? externalCode = null)
        : BaseCodeMapper("ja-JP", externalCode), ILanguage { }

    internal record THLanguage(string? externalCode = null)
        : BaseCodeMapper("th-TH", externalCode), ILanguage { }

    internal record KRLanguage(string? externalCode = null)
        : BaseCodeMapper("ko-KR", externalCode), ILanguage { }

    internal record VNLanguage(string? externalCode = null)
        : BaseCodeMapper("vi-VN", externalCode), ILanguage { }

    internal record CNLanguage(string? externalCode = null)
        : BaseCodeMapper("zh-CN", externalCode), ILanguage { }

    internal record TWLanguage(string? externalCode = null)
        : BaseCodeMapper("zh-TW", externalCode), ILanguage { }
}
