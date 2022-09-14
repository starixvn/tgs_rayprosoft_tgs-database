using System.Threading.Tasks;

namespace TGS.Core.Infrastructures.Redis;

public interface IRedisList<T>
{
    Task AddToEndAsync(T item);

    Task AddToEndAsync(T[] items);

    Task AddToStartAsync(T item);

    Task AddToStartAsync(T[] items);

    Task ClearAsync();

    Task<long> CountAsync();

    string GetKey();

    Task<T[]> GetRangeAsync(long start, long count);

    Task<T> PopFromEndAsync();

    Task<T> PopFromStartAsync();

    void SetKeyPrefix(string keyPrefix);

    Task ShrinkAsync(long maxSize);

    Task<T[]> TakeAsync(long count, long skip = 0);
}
