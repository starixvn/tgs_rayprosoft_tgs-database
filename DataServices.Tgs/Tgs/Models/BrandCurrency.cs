using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandCurrency
{
    public virtual Brand Brand { get; set; }

    public string BrandCurrencyCode { get; set; }

    public Guid BrandId { get; set; }

    public virtual Currency Currency { get; set; }

    public string CurrencyCode { get; set; }
}
