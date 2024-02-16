namespace TGS.Core.DataServices.Tgs.Models;

public record PlayerVipLevelExpTurnoverRecord
{
    public string Hash { get; set; }
    public string PlayerCode { get; set; }
    public int Type { get; set; }
    public int Sign { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public string AdditionalData { get; set; }
    public string Remark { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid CreatedUserId { get; set; }
    public string CreatedUsername { get; set; }
    public DateTimeOffset SystemOn { get; set; }
}
