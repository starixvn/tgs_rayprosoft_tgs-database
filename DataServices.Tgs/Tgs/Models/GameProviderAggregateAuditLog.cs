using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class GameProviderAggregateAuditLog
{
    public Guid CreatedByUserId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public Guid? GameProviderId { get; set; }

    public int Id { get; set; }
}
