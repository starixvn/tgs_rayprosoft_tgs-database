#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerBucketEventSource
{
    public Guid BucketId { get; set; }

    public decimal ChangeAmount { get; set; }

    public string ChangeSets { get; set; } = default!;

    public DateTime CreatedOn { get; set; }

    public string? ExternalId { get; set; }

    public string FillType { get; set; } = default!;

    public Guid Id { get; set; }

    public string? Remark { get; set; }
}
