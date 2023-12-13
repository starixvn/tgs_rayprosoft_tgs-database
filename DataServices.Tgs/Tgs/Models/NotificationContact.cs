using System;
using System.Text.Json;

namespace TGS.Core.DataServices.Tgs.Models;

public class NotificationContact
{
    public Guid ResellerId { get; set; }

    public Guid LicenseeId { get; set; }

    public Guid BrandId { get; set; }

    public int Type { get; set; }

    public string Contacts { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}
