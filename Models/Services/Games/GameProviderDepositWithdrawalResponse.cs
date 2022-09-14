using System;

namespace TGS.Core.Models.Services.Games;

public record GameProviderDepositWithdrawalResponse
{
    public Guid TransactionsId { get; set; }
    public Guid TransactionGameProviderId { get; set; }
    public decimal Balance { get; set; }
}
