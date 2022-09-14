using System;

namespace TGS.Core.Models.Services.Games;

public record GameProviderDepositWithdrawalRequest
{
    public Guid GameProviderId { get; set; }
    public Guid BrandId { get; set; }
    public Guid PlayerWalletId { get; set; }
    public string PlayerCode { get; set; }
    public string GameProviderTransactionId { get; set; }
    public decimal Amount { get; set; }
}
