#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class GroupUser
{
    public Guid GroupId { get; set; }

    public string System { get; set; } = default!;

    public string UserId { get; set; } = default!;
}
