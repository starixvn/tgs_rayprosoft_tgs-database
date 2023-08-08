#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class Function
{
    public DateTime CreatedOn { get; set; }

    public string Features { get; set; } = default!;

    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public Guid SnapshotId { get; set; }

    public string Status { get; set; } = default!;

    public string System { get; set; } = default!;

    public string Type { get; set; } = default!;

    public DateTime UpdatedOn { get; set; }
}
