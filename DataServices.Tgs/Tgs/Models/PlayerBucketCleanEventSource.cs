#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerBucketCleanEventSource
{
    public string ChangeSets { get; set; } = default!;

    public DateTime CreatedOn { get; set; }

    public Guid FormId { get; set; }

    public Guid Id { get; set; }
}
