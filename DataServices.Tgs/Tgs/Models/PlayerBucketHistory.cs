using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerBucketHistory
{
    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset From { get; set; }

    public int Id { get; set; }

    public Guid PlayerBucketId { get; set; }

    public string PlayerCode { get; set; }

    public string RoundData { get; set; }

    public DateTimeOffset To { get; set; }

    public decimal Turnover { get; set; }
}
