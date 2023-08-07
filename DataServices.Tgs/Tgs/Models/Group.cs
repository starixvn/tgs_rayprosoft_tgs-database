#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class Group
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string System { get; set; } = default!;
}
