#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class WithdrawFormEventSource
{
    public string Action { get; set; } = default!;

    public string ChangeSets { get; set; } = default!;

    public DateTime CreatedOn { get; set; }

    public Guid FormId { get; set; }

    public Guid Id { get; set; }

    public string? ModifyUser { get; set; }
}
