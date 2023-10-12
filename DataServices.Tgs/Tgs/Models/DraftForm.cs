#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class DraftForm
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public string Description { get; set; } = default!;

    public string LocalizedArticles { get; set; } = default!;

    public string Status { get; set; } = default!;

    public string Modifier { get; set; } = default!;

    public DateOnly? PublishDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }
}
