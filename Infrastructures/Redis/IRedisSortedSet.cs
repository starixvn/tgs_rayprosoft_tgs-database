using System.Collections.Generic;
using System.Threading.Tasks;

namespace TGS.Core.Infrastructures.Redis;

public interface IRedisSortedSet<T>
{
    Task AddAsync(double score, T item);

    Task AddRangeAsync(IEnumerable<ScoredItem<T>> items);

    Task<int> CountAsync();

    string GetKey();

    Task<T> GetWithMaxScoreAsync();

    Task<T> GetWithMinScoreAsync();

    void SetKeyPrefix(string keyPrefix);

    Task<T[]> TakeAsync(int count);

    Task<T[]> TakeDescendingAsync(int count);

    Task TrimLowerAsync(int targetLength);

    Task TrimUpperAsync(int targetLength);
}
