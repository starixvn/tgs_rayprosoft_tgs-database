namespace TGS.Core.DataServices.Tgs.Models;

public class LogRecord
{
    public string Exception { get; set; }

    public Guid Id { get; set; }

    public int Level { get; set; }

    public string Logger { get; set; }

    public string Message { get; set; }

    public DateTimeOffset RecordedOn { get; set; }

    public string ServerName { get; set; }

    public Guid TrackingId { get; set; }
}
