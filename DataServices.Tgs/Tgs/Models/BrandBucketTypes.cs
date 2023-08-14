#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandBucketTypes
{
    public Guid BrandId { get; set; }

    public string BucketTypes { get; set; } = default!;
}
