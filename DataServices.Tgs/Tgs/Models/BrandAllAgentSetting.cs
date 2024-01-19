using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandAllAgentSetting
{
    public Guid BrandId { get; set; }

    public bool Switch { get; set; }

    public SettlementIntervalType? SettlementIntervalType { get; set; }
}
