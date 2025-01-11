using ShoppingPlace.Core.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Core.Repositories
{
    public interface IRepositoryGenerice<TEntity, TKey> : IAsyncDisposable where TEntity : BaseEntity<TKey>
    {
        IQueryable<TEntity> GetAll(int? numberPage = null, int? numberRow = null);
        TEntity Get(TKey key);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, int? numberPage = null, int? numberRow = null);
        void Insert(TEntity entity);
        TEntity InsertAndGetEntity(TEntity entity);

        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey key);
        void DeleteRange(Expression<Func<TEntity, bool>> predicate);
        void InsertRange(Expression<Func<TEntity, bool>> predicate);
        void InsertRange(List<TEntity> entities);
        void UpdateRange(Expression<Func<TEntity, bool>> predicate);
        TKey AddAndGetId(TEntity entity);

        #region async
        Task<TKey> AddAndGetIdAsync(TEntity entity);
        Task<TEntity> GetAsync(TKey key);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task InsertAsync(TEntity entity);
        Task<TEntity> InsertAndGetEntityAsync(TEntity entity);
        Task InsertRangeAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion
        #region SaveChange

        Task<int> SaveChangeAsync();


        int SaveChange();

        #endregion


    }
}
