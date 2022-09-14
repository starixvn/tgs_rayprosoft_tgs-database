using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandLanguage
{
    public virtual Brand Brand { get; set; }

    public string BrandCultureCode { get; set; }

    public Guid BrandId { get; set; }

    public string CultureCode { get; set; }

    public virtual Language Language { get; set; }
}
