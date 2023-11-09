using System;
using TGS.Core.Models.Enums;

#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerAgentRelation
{
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }
    public string PlayerCode { get; set; }
    public Player Player { get; set; }
    public Guid AgentId { get; set; }
    public Agent Agent { get; set; }
    public PlayerAgentStatus Status { get; set; }
}
