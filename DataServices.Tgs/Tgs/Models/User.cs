using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class User
{
    public string CreatedByUsername { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public virtual Department Department { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid Id { get; set; }

    public string LastLoginIp { get; set; }

    public DateTimeOffset? LastLoginTime { get; set; }

    public string Name { get; set; }

    public byte[] Password { get; set; }

    public virtual Role Role { get; set; }

    public Guid RoleId { get; set; }

    public byte[] Salt { get; set; }

    public UserStatus Status { get; set; }

    public string TimeZone { get; set; }

    public string UpdatedByUsername { get; set; }

    public DateTimeOffset UpdatedOn { get; set; }

    public string Username { get; set; }
}
