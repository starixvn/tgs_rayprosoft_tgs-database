using System;
using System.Collections.Generic;

namespace TGS.Core.DataServices.Tgs.Models;

public class VipLevel
{
    public decimal BirthReward { get; set; }

    public virtual Brand Brand { get; set; }

    public Guid BrandId { get; set; }

    public decimal CardGameRebatePercentage { get; set; }

    public string CreatedByUsername { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public Guid Id { get; set; }

    public int Level { get; set; }

    public decimal LevelKeepAccumulateBetAmount { get; set; }

    public decimal LevelKeepAccumulateDeposit { get; set; }

    public bool LevelKeepCondition { get; set; }

    public decimal LevelUpAccumulateBetAmount { get; set; }

    public decimal LevelUpAccumulateDeposit { get; set; }

    public decimal LiveDealerRebatePercentage { get; set; }

    public decimal LotteryRebatePercentage { get; set; }

    public virtual ICollection<BrandPaymentVipLevel> PaymentVipLevels { get; set; }

    public virtual ICollection<Player> Players { get; set; }

    public decimal PromotionReward { get; set; }

    public virtual ICollection<Promotion> Promotions { get; set; }

    public decimal QuarterlyReward { get; set; }

    public decimal SlotRebatePercentage { get; set; }

    public decimal SportsRebatePercentage { get; set; }

    public string UpdatedByUsername { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }

    public decimal VirtualSportsRebatePercentage { get; set; }
}
