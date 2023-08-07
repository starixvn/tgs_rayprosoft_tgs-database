#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class Permission
{
    public string Action { get; set; } = default!;

    public DateTime CreatedOn { get; set; }

    public Guid FunctionId { get; set; }

    public Guid Id { get; set; }

    public string Identity { get; set; } = default!;

    public string IdentityType { get; set; } = default!;

    public int Order { get; set; }

    public string System { get; set; } = default!;
}
