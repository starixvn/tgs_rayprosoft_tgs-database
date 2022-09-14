using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class StationLetterPlayer
{
    public bool IsRead { get; set; }

    public virtual Player Player { get; set; }

    public string PlayerCode { get; set; }

    public DateTimeOffset? ReadOn { get; set; }

    public virtual StationLetter StationLetter { get; set; }

    public Guid StationLetterId { get; set; }
}
