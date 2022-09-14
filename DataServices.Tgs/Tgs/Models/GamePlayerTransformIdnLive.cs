using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class GamePlayerTransformIdnLive
{
    public string Configuration { get; set; } = default!;

    public DateTimeOffset CreatedOn { get; set; }

    public int Id { get; set; }

    public string PlayerCode { get; set; } = default!;

    public DateTimeOffset UpdatedOn { get; set; }
}
