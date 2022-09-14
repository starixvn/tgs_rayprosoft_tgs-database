using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class ResellerLanguage
{
    public string CultureCode { get; set; }

    public virtual Language Language { get; set; }

    public virtual Reseller Reseller { get; set; }

    public Guid ResellerId { get; set; }
}
