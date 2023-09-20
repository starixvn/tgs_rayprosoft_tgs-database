using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandPaymentSettings
{
    public Guid BrandId { get; set; }

    public int? PlayerBankInfoCountLimit { get; set; }
}
