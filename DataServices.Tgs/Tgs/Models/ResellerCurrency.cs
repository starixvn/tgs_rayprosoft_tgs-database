using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class ResellerCurrency
{
    public virtual Currency Currency { get; set; }

    public string CurrencyCode { get; set; }

    public virtual Reseller Reseller { get; set; }

    public Guid ResellerId { get; set; }
}
