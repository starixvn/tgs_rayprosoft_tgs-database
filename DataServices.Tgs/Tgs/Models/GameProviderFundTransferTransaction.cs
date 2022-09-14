using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class GameProviderFundTransferTransaction
{
    public decimal Amount { get; set; }

    public decimal Balance { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string Description { get; set; }

    public string FromWallet { get; set; }

    public FundSource FundSource { get; set; }

    public Guid GameProviderFundTransferTransactionId { get; set; }

    public Guid GameProviderId { get; set; }

    public string GameProviderTransactionId { get; set; }

    public string PlayerCode { get; set; }

    public FundTransferTransactionStatus Status { get; set; }

    public string ToWallet { get; set; }

    public Guid? TransactionId { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }

    public Guid WalletId { get; set; }
}
