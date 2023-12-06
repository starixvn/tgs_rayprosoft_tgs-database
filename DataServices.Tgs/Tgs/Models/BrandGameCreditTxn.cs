using System;
using System.Text.Json;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGameCreditTxn
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public int Type { get; set; }
    public decimal Money { get; set; }
    public decimal Amount { get; set; }
    public string Remark { get; set; }
    public JsonDocument Expansions { get; set; }
    public Guid CreatedUserId { get; set; }
    public string CreatedUsername { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}
