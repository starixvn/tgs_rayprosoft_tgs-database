using System;
using System.Collections.Generic;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGroup
{
    public virtual Brand Brand { get; set; }

    public virtual ICollection<BrandGroupGame> BrandGames { get; set; }

    public virtual ICollection<BrandGroupBetLimit> BrandGroupBetLimits { get; set; }

    public Guid BrandId { get; set; }

    public string CreatedByUsername { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string Description { get; set; }

    public Guid Id { get; set; }

    public bool IsSports { get; set; }

    public string Name { get; set; }

    public string UpdatedByUsername { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}
