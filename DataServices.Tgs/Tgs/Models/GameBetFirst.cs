namespace TGS.Core.DataServices.Tgs.Models;

public record GameBetFirst
{
    public Guid Id { get; set; }
    public Guid GameBetId { get; set; }
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
    public DateTimeOffset ExternalClosedOn { get; set; }
    public DateTimeOffset ExternalPayoffOn { get; set; }
    public DateTimeOffset ExternalResettleOn { get; set; }
    public int BetState { get; set; }
    public int BetType { get; set; }
    public int FreeGameState { get; set; }
    public int GambleState { get; set; }
    public int CashoutState { get; set; }
    public int ResettleState { get; set; }
    public int JackpotState { get; set; }
    public decimal CurrencyRatio { get; set; }
    public decimal Bet { get; set; }
    public decimal ValidBet { get; set; }
    public decimal Settle { get; set; }
    public decimal Commission { get; set; }
    public decimal Turnover { get; set; }
    public decimal WinLoss { get; set; }
    public decimal Jackpot { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ClosedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
    public DateTimeOffset FirstOn { get; set; }
    public string AdditionalData { get; set; }
}
