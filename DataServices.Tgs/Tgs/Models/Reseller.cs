using System;
using System.Collections.Generic;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class Reseller : BaseEntity<Guid>
{
    public virtual ICollection<ResellerBetLimit> BetLimits { get; set; }

    public BusinessType BusinessType { get; set; }

    public virtual ICollection<ResellerCurrency> Currencies { get; set; }

    public virtual ICollection<Department> Departments { get; set; }

    public string Description { get; set; }

    public virtual ICollection<ResellerGameProvider> GameProviders { get; set; }

    public virtual ICollection<ResellerLanguage> Languages { get; set; }

    public virtual ICollection<Licensee> Licensees { get; set; }

    public string OperationalEmail { get; set; }

    public Status Status { get; set; }
}
