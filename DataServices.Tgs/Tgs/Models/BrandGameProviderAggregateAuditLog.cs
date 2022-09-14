using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGameProviderAggregateAuditLog
{
    public Guid? BrandId { get; set; }

    public Guid CreatedByUserId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public int Id { get; set; }
}
