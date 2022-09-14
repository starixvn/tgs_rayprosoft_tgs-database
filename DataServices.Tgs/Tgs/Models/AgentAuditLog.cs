using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentAuditLog
{
    public virtual Agent Agent { get; set; }

    public Guid AgentId { get; set; }

    public string CreatedByUsername { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public Guid Id { get; set; }

    public AgentOperation Operation { get; set; }
}
