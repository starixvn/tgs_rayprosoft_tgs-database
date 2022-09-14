namespace TGS.Core.Infrastructures.Redis;

public class ScoredItem<T>
{
    public T Item { get; set; }

    public double Score { get; set; }

    public ScoredItem(double score, T item)
    {
        Score = score;
        Item = item;
    }
}
