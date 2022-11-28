#nullable enable

using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerRegisterPlatform
{
    public Guid BrandId { get; set; }

    public string PlayerCode { get; set; } = default!;

    public RegisterPlatformType Type { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedByUsername { get; set; } = default!;
}
