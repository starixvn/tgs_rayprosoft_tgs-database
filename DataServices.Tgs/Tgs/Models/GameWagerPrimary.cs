namespace TGS.Core.DataServices.Tgs.Models;

public record GameWagerPrimary
{
    public Guid Id { get; set; }
    public Guid GameProviderId { get; set; }
    public Guid GameProviderConfigurationId { get; set; }
    public int GameId { get; set; }
    public Guid ResellerId { get; set; }
    public Guid LicenseeId { get; set; }
    public Guid BrandId { get; set; }
    public string PlayerCode { get; set; }
    public string CurrencyCode { get; set; }
    public Guid WalletId { get; set; }
    public string ExternalRoundId { get; set; }
    public string ExternalWagerId { get; set; }
    public DateTimeOffset ExternalCreatedOn { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}
