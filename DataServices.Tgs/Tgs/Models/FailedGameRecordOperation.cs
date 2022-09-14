using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class FailedGameRecordOperation
{
    public FailedGameRecordOperationAutoStatus AutoStatus { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string Detail { get; set; }

    public string ExternalId { get; set; }

    public string ExternalRoundId { get; set; }

    public int GameId { get; set; }

    public string GameProviderCode { get; set; }

    public Guid GameProviderId { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; }

    public FailedGameRecordOperationProcesStatus ProcesStatus { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}
