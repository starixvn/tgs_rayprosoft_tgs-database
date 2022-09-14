using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerVipLevelAggregate
{
    public Guid BrandId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public decimal DepositAmount { get; set; }

    public DateTimeOffset FromOn { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; }

    public DateTimeOffset ToOn { get; set; }

    public decimal Turnover { get; set; }

    public DateTimeOffset UpdateOn { get; set; }
}
