using System;
using TGS.Core.Models.Enums;

#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerAgentRelation
{
    public Guid BrandId { get; set; }

    public string PlayerCode { get; set; } = null!;

    public Guid AgentId { get; set; }

    public PlayerAgentStatus Status { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;

    public virtual Agent Agent { get; set; } = null!;
}
