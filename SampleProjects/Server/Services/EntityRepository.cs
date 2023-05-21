﻿using IdentityModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SampleProjects.Server.Data;
using System.Linq.Expressions;
using SampleProjects.Server.Models;
using System;

namespace SampleProjects.Server.Services
{
    public class EntityRepository<TEntity, TModel> : IEntityRepository<TEntity, TModel>
        where TEntity : BaseEntity
    {
        protected ApplicationDbContext _context;
        //private readonly IUnitOfWork _uow;
        internal DbSet<TEntity> _dbSet;

        public EntityRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<int> AddAndSaveChangesAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddRangeAndSaveChangesAsync(IList<TEntity> entitys)
        {
            await _dbSet.AddRangeAsync(entitys);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<EntityEntry<TEntity>> AddAsync(TEntity item)
        {
            return await _dbSet.AddAsync(item);
        }

        public async Task AddRangeAsync(IList<TEntity> items)
        {
            await _dbSet.AddRangeAsync(items);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.AnyAsync(expression);
        }
        public Task<bool> AnyAsync()
        {
            return _dbSet.AnyAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> _pridicate)
        {
            try
            {
                var entity = await _dbSet.Where(_pridicate)
                                        .FirstOrDefaultAsync();

                switch (entity)
                {
                    case null:
                        throw new ArgumentNullException(nameof(entity));

                    case ISoftDeletedEntity softDeletedEntity:
                        softDeletedEntity.Deleted = true;
                        await EditAsync(entity);
                        break;

                    default:
                        _dbSet.Remove(entity);
                        break;
                }

                return await SaveChangesAsync();
            }
            catch
            {
                return 0;
            }
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> _pridicate)
        {
            return await _dbSet.FindAsync(_pridicate);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> _pridicate)
        {
            return await _dbSet.FirstOrDefaultAsync(_pridicate);
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> _pridicate)
        {
            var query = await _dbSet.Where(_pridicate).ToListAsync();

            return AddDeletedFilter(query, false).ToList();
        }

        protected IEnumerable<TEntity> AddDeletedFilter(IList<TEntity> query, bool includeDeleted)
        {
            if (includeDeleted)
                return query;

            if (typeof(TEntity).GetInterface(nameof(ISoftDeletedEntity)) == null)
                return query;

            return query.OfType<ISoftDeletedEntity>().Where(entry => !entry.Deleted).OfType<TEntity>();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            var query = await _dbSet.ToListAsync();

            return AddDeletedFilter(query, false).ToList();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, TEntity>> expression)
        {
            var query = await _dbSet.Select(expression).ToListAsync();

            return AddDeletedFilter(query, false).ToList();
        }

        public async Task<IList<TEntity>> GetAllAsync
            (Expression<Func<TEntity, bool>> _pridicate, Expression<Func<TEntity, TEntity>> _selectList)
        {
            var query = await _dbSet.Where(_pridicate).Select(_selectList).ToListAsync();

            return AddDeletedFilter(query, false).ToList();
        }

        #region UpdateUseZEntity
        //public async Task<int> EditAsync(Expression<Func<TEntity, bool>> predicate,
        //    Expression<Func<TEntity, TEntity>> expression)
        //{
        //    var result = await _dbSet.Where(predicate)
        //        .UpdateFromQueryAsync(expression);
        //    return result;
        //}
        #endregion

        public async Task<int> EditAsync(TEntity entity)
        {
            #region OtherMethod
            //_context.Entry<TEntity>(entity).State = EntityState.Modified;
            #endregion
            _dbSet.Update(entity);
            await SaveChangesAsync();
            return 1;
        }

        public async Task<int> EditAsync(Expression<Func<TEntity, TEntity>> predicate
        , Expression<Func<TEntity, TEntity>> entity)
        {
            _context.Entry(predicate).CurrentValues.SetValues(entity);
            return 1;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> _pridicate, Expression<Func<TEntity, TEntity>> selectItem)
        {
            return await _dbSet.Where(_pridicate).Select(selectItem).FirstOrDefaultAsync();
        }
    }
}
