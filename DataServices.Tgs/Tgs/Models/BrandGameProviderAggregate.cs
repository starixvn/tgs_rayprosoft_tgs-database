using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGameProviderAggregate
{
    public int AuditLogId { get; set; }

    public decimal BetAmount { get; set; }

    public Guid BrandId { get; set; }

    public decimal Commission { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string CurrencyCode { get; set; }

    public Guid GameProviderId { get; set; }

    public GameType GameType { get; set; }

    public int Id { get; set; }

    public DateTimeOffset ReportDate { get; set; }

    public decimal SettleAmount { get; set; }

    public int TransactionCount { get; set; }

    public decimal Turnover { get; set; }

    public decimal ValidBetAmount { get; set; }

    public decimal WinLoss { get; set; }
}
