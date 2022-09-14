using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandAllAgentGameType
{
    public AllAgentGameType AllAgentGameType { get; set; }

    public Guid BrandId { get; set; }

    public bool HasValidBet { get; set; }

    public bool HasWinLoss { get; set; }

    public bool Switch { get; set; }
}
