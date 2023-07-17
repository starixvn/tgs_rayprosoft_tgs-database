#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class AccountEventSource
{
    public Guid AccountId { get; set; }

    public string ChangeSets { get; set; } = default!;

    public DateTime CreatedOn { get; set; }

    public Guid Id { get; set; }
}
