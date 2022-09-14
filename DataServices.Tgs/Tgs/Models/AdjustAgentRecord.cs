using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class AdjustAgentRecord
{
    public AdjustmentType AdjustmentType { get; set; }

    public Guid AgentId { get; set; }

    public decimal Amount { get; set; }

    public Guid BrandId { get; set; }

    public string CreatedByUsername { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public Guid Id { get; set; }

    public string Remark { get; set; }

    public Guid? TransactionId { get; set; }

    public string TransferTarget { get; set; }

    public AdjustTransferType TransferType { get; set; }

    public AgentAdjustmentTransactionType Type { get; set; }
}
