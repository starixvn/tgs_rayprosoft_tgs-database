using System;
using System.Text.Json;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGameCreditSuspSetting
{
    public Guid BrandId { get; set; }
    public decimal LowRisk { get; set; }
    public string LowNotification { get; set; }
    public decimal ModerateRisk { get; set; }
    public string ModerateNotification { get; set; }
    public decimal HighRisk { get; set; }
    public string HighNotification { get; set; }
    public decimal Credit { get; set; }
    public string CreditNotification { get; set; }
    public string ManualNotification { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
}
