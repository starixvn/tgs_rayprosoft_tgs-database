using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class FunctionEventSource
{
    public string ChangeSets { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid FunctionId { get; set; }

    public Guid Id { get; set; }

    public string System { get; set; }
}
