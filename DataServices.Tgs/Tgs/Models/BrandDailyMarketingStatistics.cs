using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandDailyMarketingStatistics
{
    public Guid BrandId { get; set; }

    public int? DirectlyPlayerGamingCount { get; set; }

    public int? DirectlyPlayerRegisterCount { get; set; }

    public DateOnly ReportDate { get; set; }

    public int? TotalPlayerGamingCount { get; set; }

    public int? TotalPlayerRegisterCount { get; set; }
}
