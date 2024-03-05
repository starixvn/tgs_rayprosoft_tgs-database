using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGS.Core.DataServices.Tgs.Models;

public record GameWagerPlayerAccum
{
    public Guid ResellerId { get; set; }

    public Guid LicenseeId { get; set; }

    public Guid BrandId { get; set; }

    public string PlayerCode { get; set; }

    public DateTimeOffset AccumOn { get; set; }

    public int Count { get; set; }

    public decimal Bet { get; set; }

    public decimal ValidBet { get; set; }

    public decimal Settle { get; set; }

    public decimal Commission { get; set; }

    public decimal Turnover { get; set; }

    public decimal WinLoss { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }
}
