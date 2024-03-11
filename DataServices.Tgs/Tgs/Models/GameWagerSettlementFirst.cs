namespace TGS.Core.DataServices.Tgs.Models;

public record GameWagerSettlementFirst
{
    public Guid Id { get; set; }
    public Guid GameWagerPrimaryId { get; set; }
    public int WagerState { get; set; }
    public int WagerType { get; set; }
    public int ClosedState { get; set; }
    public int VoidState { get; set; }
    public int CancelState { get; set; }
    public int FreeGameState { get; set; }
    public int GambleState { get; set; }
    public int CashoutState { get; set; }
    public int ResettleState { get; set; }
    public decimal CurrencyRatio { get; set; }
    public decimal Bet { get; set; }
    public decimal ValidBet { get; set; }
    public decimal Settle { get; set; }
    public decimal Commission { get; set; }
    public decimal Turnover { get; set; }
    public decimal WinLoss { get; set; }
    public DateTimeOffset ExternalCreatedOn { get; set; }
    public DateTimeOffset ExternalClosedOn { get; set; }
    public DateTimeOffset ExternalPayoffOn { get; set; }
    public DateTimeOffset ExternalResettleOn { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ClosedOn { get; set; }
    public DateTimeOffset FirstOn { get; set; }
}
