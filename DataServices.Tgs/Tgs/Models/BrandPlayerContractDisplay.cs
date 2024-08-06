namespace TGS.Core.DataServices.Tgs.Models;

public class BrandPlayerContractDisplay
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public string Name { get; set; }

    public bool IsVisualized { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; }

    public DateTime UpdatedOn { get; set; }

    public string UpdatedBy { get; set; }
}