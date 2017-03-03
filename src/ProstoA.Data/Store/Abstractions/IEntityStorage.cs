using System.Threading.Tasks;

using ProstoA.Data.Model.Abstractions;

namespace ProstoA.Data.Store {
    public interface IEntityStorage {
        IDataCollection<TEntity> Collection<TEntity>() where TEntity : class;

        //Task<TResult> ExecuteQuery<TResult>(IDataQuery<TResult> query);

        Task AddOrUpdate(params IObjectValue[] items);

        Task Remove(params IObjectValue[] items);
    }
}