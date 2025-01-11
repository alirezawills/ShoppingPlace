using Microsoft.EntityFrameworkCore;
using ShoppingPlace.Core.BaseClass;
using ShoppingPlace.Core.General;
using ShoppingPlace.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Database
{
    public class RepositoryGenerice<TEntity, TKey> : IRepositoryGenerice<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly ShoppingPlaceDbContext _db;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMySession _session;

        public RepositoryGenerice(ShoppingPlaceDbContext db, IMySession session)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
            _session = session;
        }

        public TKey AddAndGetId(TEntity entity)
        {
            entity.InsertBy = _session.UserId ?? 0;
            var rec = _dbSet.Add(entity);

            var en = rec.Entity;
            return (TKey)en.Id;
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeleteDate = DateTime.Now;
            entity.DeleteBy = _session.UserId ?? 0;
            Update(entity);

        }

        public void Delete(TKey key)
        {
            var rec = _dbSet.Find(key);
            rec.IsDeleted = true;
            rec.DeleteDate = DateTime.Now;
            rec.DeleteBy = _session.UserId ?? 0;
            _dbSet.Update(rec);
            _db.SaveChanges(true);
        }

        public void DeleteRange(Expression<Func<TEntity, bool>> predicate)
        {
            var rec = _dbSet.Where(predicate).ToList();
            foreach (var item in rec)
            {
                item.IsDeleted = true;
                item.DeleteDate = DateTime.Now;
                item.DeleteBy = _session.UserId ?? 0;
            }
            _dbSet.UpdateRange(rec);

        }

        public TEntity Get(TKey key)
        {
            try
            {
                var rec = _dbSet.Find(key);
                return rec;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            var rec = _dbSet.FirstOrDefault(predicate);
            return rec;
        }

        public IQueryable<TEntity> GetAll(int? numberPage = null, int? numberRow = null)
        {
            try
            {
                var rec = _dbSet.Where(x => x.IsDeleted == false).AsQueryable();
                if (numberPage != null)
                {
                    rec = rec.Skip((numberPage.Value - 1) * numberRow.Value).Take(numberRow.Value);
                }
                return rec;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, int? numberPage = null, int? numberRow = null)
        {
            var rec = _dbSet.Where(predicate).Where(x => x.IsDeleted == false).AsQueryable();
            if (numberPage != null)
            {
                rec = rec.Skip((numberPage.Value - 1) * numberRow.Value).Take(numberRow.Value);
            }
            return rec;
        }


        public void Insert(TEntity entity)
        {
            entity.InsertDate = DateTime.Now;
            entity.InsertBy = _session.UserId;
            _dbSet.Add(entity);

        }
        public TEntity InsertAndGetEntity(TEntity entity)
        {
            try
            {
                entity.InsertDate = DateTime.Now;
                entity.InsertBy = _session.UserId;
                var dataEntity = _dbSet.Add(entity);
                _db.SaveChanges();
                return dataEntity.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }

        public void InsertRange(Expression<Func<TEntity, bool>> predicate)
        {
            var rec = _dbSet.Where(predicate).ToList();
            rec.ForEach(x =>
            {
                x.InsertDate = DateTime.Now;
                x.InsertBy = _session.UserId;
            });
            _dbSet.AddRange(rec);


        }
        public void InsertRange(List<TEntity> entities)
        {

            entities.ForEach(x =>
            {
                x.InsertDate = DateTime.Now;
                x.InsertBy = _session.UserId;
            });
            _dbSet.AddRange(entities);


        }

        public void Update(TEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = _session.UserId;
            _dbSet.Update(entity);


        }


        public void UpdateRange(Expression<Func<TEntity, bool>> predicate)
        {

            var rec = _dbSet.Where(predicate).ToList();
            rec.ForEach(x =>
            {
                x.UpdateDate = DateTime.Now;
                x.UpdateBy = _session.UserId;
            });
            _dbSet.UpdateRange(rec);

        }
        #region async
        public async Task<TKey> AddAndGetIdAsync(TEntity entity)
        {
            entity.InsertDate = DateTime.Now;
            entity.InsertBy = _session.UserId;
            var rec = await _dbSet.AddAsync(entity);

            var en = rec.Entity;
            return (TKey)en.Id;
        }

        public async Task<TEntity> GetAsync(TKey key)
        {
            var rec = await _dbSet.FindAsync(key);
            return rec;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var rec = await _dbSet.FirstOrDefaultAsync(predicate);
            return rec;
        }
        public async Task InsertAsync(TEntity entity)
        {
            entity.InsertDate = DateTime.Now;
            entity.InsertBy = _session.UserId;
            await _dbSet.AddAsync(entity);

        }
        public async Task<TEntity> InsertAndGetEntityAsync(TEntity entity)
        {
            try
            {
                entity.InsertDate = DateTime.Now;
                entity.InsertBy = _session.UserId;
                var dataEntity = await _dbSet.AddAsync(entity);
                await _db.SaveChangesAsync();
                return dataEntity.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }

        public async Task InsertRangeAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var rec = await _dbSet.Where(predicate).ToListAsync();
            rec.ForEach(x =>
            {
                x.InsertDate = DateTime.Now;
                x.InsertBy = _session.UserId;
            });
            await _dbSet.AddRangeAsync(rec);


        }
        #endregion

        #region SaveChange

        public async Task<int> SaveChangeAsync()
        {
            return await _db.SaveChangesAsync();
        }
        public int SaveChange()
        {
            return _db.SaveChanges();
        }
        #endregion
        public async ValueTask DisposeAsync()
        {
            if (_db != null)
            {
                await _db.DisposeAsync();
            }
        }




    }
}
