#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs;

public class PromotionEventSource
{
    public string Action { get; set; } = default!;

    public string ChangeSets { get; set; } = default!;

    public DateTime CreatedOn { get; set; }

    public Guid PromotionId { get; set; }

    public Guid Id { get; set; }

    public string? ModifyUser { get; set; }
}
