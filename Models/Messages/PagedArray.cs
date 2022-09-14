namespace TGS.Core.Models.Messages;

public class PagedArray<T>
{
    public T[] Items { get; private set; }

    public int TotalCount { get; private set; }

    public PagedArray(int totalCount, T[] items)
    {
        TotalCount = totalCount;
        Items = items;
    }
}
