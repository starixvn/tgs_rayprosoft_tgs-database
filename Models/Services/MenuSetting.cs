namespace TGS.Core.Models.Services;

public class MenuSetting(string code, MenuSetting[] subMenus = null)
{
    public string Code { get; } = code;

    public bool IsDisplay { get; init; } = true;

    public IList<MenuSetting> SubMenus { get; } = subMenus;
}
