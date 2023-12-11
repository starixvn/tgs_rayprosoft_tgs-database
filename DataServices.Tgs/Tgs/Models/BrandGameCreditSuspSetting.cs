using System;
using System.Text.Json;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGameCreditSuspSetting
{
    public Guid BrandId { get; set; }
    public decimal LowRisk { get; set; }
    public JsonDocument LowNotification { get; set; }
    public decimal ModerateRisk { get; set; }
    public JsonDocument ModerateNotification { get; set; }
    public decimal HighRisk { get; set; }
    public JsonDocument HighNotification { get; set; }
    public decimal Credit { get; set; }
    public JsonDocument CreditNotification { get; set; }
    public JsonDocument ManualNotification { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
}
