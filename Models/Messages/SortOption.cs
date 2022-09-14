namespace TGS.Core.Models.Messages;

public class SortOption
{
    public bool IsDescending { get; set; }

    public string PropertyName { get; set; }

    public SortOption(string propertyName, bool isDescending)
    {
        IsDescending = isDescending;
        PropertyName = propertyName;
    }
}
