using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerBucket
{
    public decimal BucketAmount { get; set; }

    public BucketType BucketType { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public decimal CurrentBucketAmount { get; set; }

    public Guid Id { get; set; }

    public bool IsFull { get; set; }

    public virtual Player Player { get; set; }

    public string PlayerCode { get; set; }
}
