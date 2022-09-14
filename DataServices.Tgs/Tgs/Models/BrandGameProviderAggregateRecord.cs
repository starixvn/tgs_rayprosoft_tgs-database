using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGameProviderAggregateRecord
{
    public int AuditLogId { get; set; }

    public Guid BrandId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string Data { get; set; }

    public int Id { get; set; }
}
