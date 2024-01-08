using System;
using System.Collections.Generic;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendSnapshot
{
    public Guid Id { get; set; }
    public string Data { get; set; }
    public DateTime CreatedOn { get; set; }
}
