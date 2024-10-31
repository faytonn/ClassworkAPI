using Classwork.Persistence.Repositories.Interface;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TContext> : IRepositoryAsync<TEntity> where TEntity : Entity where TContext : DbContext
    {
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }


        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            if (include != null) query = include(query);

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<Pagination<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                           int index = 0, int size = 10, bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();

            if (!enableTracking) queryable = queryable.AsNoTracking();

            if (include != null) queryable = include(queryable);

            if (predicate != null) queryable = queryable.Where(predicate);

            if (orderBy != null) queryable = orderBy(queryable);

            return await queryable.ToPaginateAsync(index, size);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {

            var entityEntry = await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {

            var entityEntry = Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {

            var entityEntry = Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();

            return entityEntry.Entity;
        }

     
        
    }
}
