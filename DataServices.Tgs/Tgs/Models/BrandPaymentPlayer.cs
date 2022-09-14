using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandPaymentPlayer
{
    public virtual BrandPayment BrandPayment { get; set; }

    public Guid BrandPaymentId { get; set; }

    public PlayerListType ListType { get; set; }

    public virtual Player Player { get; set; }

    public string PlayerCode { get; set; }
}
