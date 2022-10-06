using System;

#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandPlayerBankInfoCheckFlag
{
    public Guid BrandId { get; set; }

    public bool IsEnabled { get; set; }
}
