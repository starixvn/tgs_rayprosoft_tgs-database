using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class LicenseeCurrency
{
    public virtual Currency Currency { get; set; }

    public string CurrencyCode { get; set; }

    public virtual Licensee Licensee { get; set; }

    public Guid LicenseeId { get; set; }
}
