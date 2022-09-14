using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGameProviderSchedule
{
    public virtual BrandGameProvider BrandGameProvider { get; set; }

    public Guid BrandGameProviderId { get; set; }

    public DayOfWeek? DayOfWeek { get; set; }

    public DateTimeOffset From { get; set; }

    public Guid Id { get; set; }

    public bool IsDefault { get; set; }

    public SwitchStatus Status { get; set; }

    public DateTimeOffset To { get; set; }
}
