using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PaymentChannel
{
    public string Code { get; set; }

    public string Description { get; set; }

    public Guid Id { get; set; }
}
