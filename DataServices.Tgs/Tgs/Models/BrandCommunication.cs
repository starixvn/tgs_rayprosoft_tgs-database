using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandCommunication
{
    public string AppId { get; set; }

    public virtual Brand Brand { get; set; }

    public Guid BrandId { get; set; }

    public Guid Id { get; set; }

    public string Phone { get; set; }

    public string QRCodeUrl { get; set; }

    public string Type { get; set; }
}
