namespace TGS.Core.Infrastructures.WebApiServices;

public interface ILocalIpFinder
{
    IpInfo GetIpInfo(string ip);

    bool IsLocal(string ip);
}
