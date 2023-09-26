#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerEventSource
{
    public Guid BrandId { get; set; }

    public string ChangeSets { get; set; } = default!;

    public DateTime CreatedOn { get; set; }

    public Guid Id { get; set; }

    public string ModifyUser { get; set; } = default!;

    public string PlayerCode { get; set; } = default!;
}
