using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGroupGame
{
    public virtual BrandGame BrandGame { get; set; }

    public Guid BrandGameId { get; set; }

    public virtual BrandGroup BrandGroup { get; set; }

    public Guid BrandGroupId { get; set; }
}
