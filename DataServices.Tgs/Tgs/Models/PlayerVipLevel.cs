using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerVipLevel
{
    public string PlayerCode { get; set; } = default!;
    public Guid VipLevelId { get; set; } = default!;
    public int VipLevel { get; set; } = default!;
    public int AutoState { get; set; } = default!;
}
