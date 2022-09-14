using System;

namespace TGS.Core.DataServices.Tgs.Models;

public abstract class BaseEntity<T> where T : struct
{
    public string Code { get; set; }

    public string CreatedByUsername { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public T Id { get; set; }

    public string Name { get; set; }

    public string UpdatedByUsername { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}
