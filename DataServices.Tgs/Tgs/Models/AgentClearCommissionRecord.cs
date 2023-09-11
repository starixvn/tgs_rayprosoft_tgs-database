using System;

namespace TGS.Core.DataServices.Tgs.Models
{
    public class AgentClearCommissionRecord
    {
        public Guid Id { get; set; }
        public int AgentDividendId { get; set; }
        public decimal CommissionAmount { get; set; }
        public Guid ClearByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
