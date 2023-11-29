#nullable enable

using System;
using System.Collections.Generic;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendContract
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public Guid AgentId { get; set; }
    public string Name { get; set; } = default!;
    public ContractDividendType ContractDividendType { get; set; }
    public ContractStatus ContractStatus { get; set; }
    public string CreatedByUsername { get; set; } = default!;
    public string UpdatedByUsername { get; set; } = default!;
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
    public virtual Agent Agent { get; set; } = null!;
    public virtual AgentDividendContractValidNumber ValidNumberDefinition { get; set; } = null!;
    public virtual ICollection<AgentDividendContractPercentage> AgentDividendContractPercentages { get; set; } = null!;
}
