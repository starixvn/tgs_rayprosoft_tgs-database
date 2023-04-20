#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class StationLetter2
{
    public Guid? ComeFrom { get; set; }

    public string Content { get; set; } = default!;

    public bool HaveRead { get; set; }

    public Guid Id { get; set; }

    public string? Quotation { get; set; }

    public DateTime ReceivedOn { get; set; }

    public string Receiver { get; set; } = default!;

    public bool Replied { get; set; }

    public string Sender { get; set; } = default!;

    public DateTime SentOn { get; set; }

    public string Subject { get; set; } = default!;
}
