namespace TGS.Core.DataServices.Tgs.Models;

public class SmsSetting
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Code { get; set; } = default!;

    public string Setting { get; set; } = default!;

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime UpdatedOn { get; set; }
}