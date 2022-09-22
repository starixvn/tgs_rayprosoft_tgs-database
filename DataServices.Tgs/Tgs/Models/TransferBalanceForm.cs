using System;

#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class TransferBalanceForm
{
    public decimal Amount { get; set; }

    public Guid BrandId { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedUserId { get; set; } = default!;

    public string Drawee { get; set; } = default!;

    public string DraweeType { get; set; } = default!;

    public Guid Id { get; set; }

    public bool IncludeInNetProfit { get; set; }

    public string Payee { get; set; } = default!;

    public string PayeeType { get; set; } = default!;
}
