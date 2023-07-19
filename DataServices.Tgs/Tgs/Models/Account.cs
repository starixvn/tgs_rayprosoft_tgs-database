#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class Account
{
    public string Algorithm { get; set; } = default!;

    public Guid BrandId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid Id { get; set; }

    public string PasswordHash { get; set; } = default!;

    public Guid SnapshotId { get; set; }

    public string System { get; set; } = default!;

    public DateTime UpdatedOn { get; set; }

    public string UserName { get; set; } = default!;
}
