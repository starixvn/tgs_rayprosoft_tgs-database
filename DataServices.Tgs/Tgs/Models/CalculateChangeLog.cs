using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class CalculateChangeLog
{
    public Guid Id { get; set; }

    public Guid CalculateId { get; set; }

    public decimal Change { get; set; }

    public decimal Balance { get; set; }

    public DateTime RecordedOn { get; set; }

    public bool Deleted { get; set; }
}
