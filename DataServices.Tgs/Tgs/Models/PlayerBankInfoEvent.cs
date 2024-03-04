#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerBankInfoEvent
{
    public Guid Id { get; set; }

    public Guid BankInfoId { get; set; }

    public string ChangeAction { get; set; } = default!;

    public string ChangeSets { get; set; } = default!;

    public string? Modifier { get; set; }

    public DateTime ModifiedOn { get; set; }
}