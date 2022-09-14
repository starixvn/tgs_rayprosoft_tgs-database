using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerLoginRecord
{
    public virtual Brand Brand { get; set; }

    public Guid BrandId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset ExpiredOn { get; set; }

    public Guid Id { get; set; }

    public string IpAddress { get; set; }

    public PlatformType PlatformType { get; set; }

    public virtual Player Player { get; set; }

    public string PlayerCode { get; set; }

    public LoginStatus Status { get; set; }
}
