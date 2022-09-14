using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentWallet
{
    public virtual Agent Agent { get; set; }

    public Guid AgentId { get; set; }

    public decimal Balance { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public virtual Currency Currency { get; set; }

    public string CurrencyCode { get; set; }

    public Guid Id { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}
