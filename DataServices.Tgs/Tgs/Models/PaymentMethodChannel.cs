using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PaymentMethodChannel
{
    public virtual PaymentChannel Channel { get; set; }

    public Guid ChannelId { get; set; }

    public Guid Id { get; set; }

    public virtual PaymentMethod Method { get; set; }

    public Guid MethodId { get; set; }

    public virtual Payment Payment { get; set; }

    public Guid PaymentId { get; set; }

    public ActivateStatus Status { get; set; }
}
