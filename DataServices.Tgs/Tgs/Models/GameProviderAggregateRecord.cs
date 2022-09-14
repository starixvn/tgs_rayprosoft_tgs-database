using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class GameProviderAggregateRecord
{
    public int AuditLogId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string Data { get; set; }

    public Guid GameProviderId { get; set; }

    public int Id { get; set; }
}
