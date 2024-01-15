using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerVipLevelLog
{
    public Guid Id { get; set; } = default!;
    public string PlayerCode { get; set; } = default!;
    public int Type { get; set; } = default!;
    public string Before { get; set; } = default!;
    public string After { get; set; } = default!;
    public Guid CreatedUserId { get; set; }
    public string CreatedUsername { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public string Remark { get; set; } = default!;
}
