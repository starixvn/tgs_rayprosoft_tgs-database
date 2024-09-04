namespace TGS.Core.DataServices.Tgs.Models;

public class GameFundTransferTrace
{
    public Guid GameProviderId { get; set; }

    public Guid WalletId { get; set; }

    public string PlayerCode { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}