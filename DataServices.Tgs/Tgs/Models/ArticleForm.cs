#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class ArticleForm
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public string Description { get; set; } = default!;

    public string LocalizedArticles { get; set; } = default!;

    public string Status { get; set; } = default!;

    public string Modifier { get; set; } = default!;

    public DateTime UpdatedOn { get; set; }
}
