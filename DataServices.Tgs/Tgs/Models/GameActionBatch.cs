using System;
using System.Collections.Generic;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class GameActionBatch
{
    public DateTimeOffset CreatedOn { get; set; }

    public TgsApiError Error { get; set; }

    public string ErrorMessage { get; set; }

    public string ErrorsJson { get; set; }

    public string ExternalId { get; set; }

    public virtual ICollection<GameAction> GameActions { get; set; }

    public virtual GameProvider GameProvider { get; set; }

    public Guid GameProviderId { get; set; }

    public Guid Id { get; set; }

    public int TransactionsCount { get; set; }
}
