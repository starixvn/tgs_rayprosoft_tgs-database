using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGameCredit
{
    public Guid ResellerId { get; set; }

    public Guid LicenseeId { get; set; }

    public Guid BrandId { get; set; }

    public DateOnly Month { get; set; }

    public decimal InitialAmount { get; set; }

    public decimal CreditAmount { get; set; }

    public decimal DebitAmount { get; set; }

    public decimal ProfitAmount { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}
