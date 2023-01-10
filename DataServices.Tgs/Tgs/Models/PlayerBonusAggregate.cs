using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerBonusAggregate
{
    public Guid? AgentId { get; set; }

    public decimal BirthdayAmount { get; set; }

    public Guid BrandId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public int Hour { get; set; }

    public int Minute { get; set; }

    public string PlayerCode { get; set; }

    public decimal PromotionAmount { get; set; }

    public decimal RebateAmount { get; set; }

    public DateTimeOffset ReportDate { get; set; }

    public DateTimeOffset? ReportDateTime { get; set; }

    public decimal SeasonAmount { get; set; }

    public decimal UpgradeAmount { get; set; }
}
