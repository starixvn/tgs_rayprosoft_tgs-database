using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class LicenseeLanguage
{
    public string CultureCode { get; set; }

    public virtual Language Language { get; set; }

    public virtual Licensee Licensee { get; set; }

    public Guid LicenseeId { get; set; }
}
