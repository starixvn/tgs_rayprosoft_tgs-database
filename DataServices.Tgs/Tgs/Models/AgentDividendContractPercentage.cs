#nullable enable

using System;
using System.Collections.Generic;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendContractPercentage
{
    public Guid Id { get; set; }
    public int Rank { get; set; }
    public ContractGameType ContractGameType { get; set; }
    public int ValidNumber { get; set; }
    public decimal Percentage { get; set; }
    public Guid AgentDividendContractId { get; set; }
    public virtual AgentDividendContract AgentDividendContract { get; set; } = null!;
}
