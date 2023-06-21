#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class StationLetterDelivery
{
    public Guid? ComeFrom { get; set; }

    public string Content { get; set; } = default!;

    public Guid Id { get; set; }

    public string Operator { get; set; } = default!;

    public string? Receiver { get; set; }

    public string ReceiverType { get; set; } = default!;

    public string Sender { get; set; } = default!;

    public DateTime SentOn { get; set; }

    public string Subject { get; set; } = default!;
}
