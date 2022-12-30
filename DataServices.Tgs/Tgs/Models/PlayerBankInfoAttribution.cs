#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerBankInfoAttribution
{
    public byte[] BankInfoHash { get; set; } = default!;

    public Guid BrandId { get; set; }

    public string PlayerCode { get; set; } = default!;
}
