#nullable enable

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class Agent
{
    public virtual ICollection<AgentDividendCondition> AgentDividendConditions { get; set; } = default!;

    public AgentConfigStatus AgentStatus { get; set; }

    public virtual ICollection<AgentBank> Banks { get; set; } = default!;

    public virtual Brand Brand { get; set; } = default!;

    public Guid BrandId { get; set; }

    public decimal CardGameRebatePercentage { get; set; }

    public decimal CommissionPercentage { get; set; }

    public string? CreatedByUsername { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public Guid DefaultWalletId { get; set; }

    //佔成
    public decimal DividendPercentage { get; set; }

    public string? Email { get; set; }

    public Guid Id { get; set; }

    public string InvitationCode { get; set; } = default!;

    public AgentLevelType LevelType { get; set; }

    public decimal LiveDealerRebatePercentage { get; set; }

    public decimal LotteryRebatePercentage { get; set; }

    public virtual Agent? ParentAgent { get; set; }

    public Guid? ParentAgentId { get; set; }

    public byte[] Password { get; set; } = default!;

    public LTree Path { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Player> Players { get; set; } = default!;

    public string? QQ { get; set; }

    public string? RealName { get; set; }

    public DateTimeOffset RegisteredOn { get; set; }

    public string? Remarks { get; set; }

    public byte[] Salt { get; set; } = default!;

    public decimal SlotRebatePercentage { get; set; }

    public decimal SportsRebatePercentage { get; set; }

    public AgentStatus Status { get; set; }

    public virtual ICollection<Agent> SubAgents { get; set; } = default!;

    public AgentType Type { get; set; }

    public string? UpdatedByUsername { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }

    public string Username { get; set; } = default!;

    public decimal VirtualSportsRebatePercentage { get; set; }

    public virtual ICollection<AgentWallet> Wallets { get; set; } = default!;

    public string? Wechat { get; set; }

    public byte[] WithdrawPassword { get; set; } = default!;

    public byte[] WithdrawSalt { get; set; } = default!;

    public Guid? SnapshotEventId { get; set; }

    public Guid? WalletId { get; set; }
}
