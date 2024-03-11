namespace TGS.Core.DataServices.Tgs.Models;

public record GameWagerPrimaryDetail
{
    public Guid Id { get; set; }
    public Guid GameWagerPrimaryId { get; set; }
    public string AdditionalData { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
}
