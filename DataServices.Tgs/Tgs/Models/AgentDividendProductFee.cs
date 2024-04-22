
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendProductFee
{
    public Guid Id { get; set; }
    public int AgentDividendId { get; set; }
    public GameType GameType { get; set; }
    public decimal Percentage { get; set; }
    public decimal WinLossAmount { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}
