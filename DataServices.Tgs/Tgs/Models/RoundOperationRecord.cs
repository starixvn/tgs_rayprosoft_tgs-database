using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class RoundOperationRecord
{
    public DateTimeOffset CreatedOn { get; set; }

    public Guid Id { get; set; }

    public string NewData { get; set; }

    public string OldData { get; set; }

    public Guid OperatorId { get; set; }

    public string Remark { get; set; }

    public Guid RoundId { get; set; }
}
