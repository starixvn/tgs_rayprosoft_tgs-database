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
    public decimal GradeIntervalLimit { get; set; }
    public ContractDividendType ContractDividendType { get; set; }
    public ContractStatus ContractStatus { get; set; }
    public decimal ValidBetAmount { get; set; }
    public decimal DepositAmount { get; set; }
    public int BetDays { get; set; }
    public int[] GameTypes { get; set; } = default!;
    public string CreatedByUsername { get; set; } = default!;
    public string UpdatedByUsername { get; set; } = default!;
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
}
