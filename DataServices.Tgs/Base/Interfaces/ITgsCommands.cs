using System.Threading.Tasks;

namespace TGS.Core.DataServices.Base.Interfaces;

public interface ITgsCommands<in TEntity> where TEntity : class
{
    Task BatchUpdateAsync(TEntity[] obj);

    Task CreateAsync(TEntity obj);

    Task DeleteAsync(TEntity obj);

    Task UpdateAsync(TEntity obj);
}
