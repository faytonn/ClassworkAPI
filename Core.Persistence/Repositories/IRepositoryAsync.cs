﻿using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public interface IRepositoryAsync<T> where T : Entity
{
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> GetAsync(int id);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                     Func<IQueryable<T>, 
                     IIncludableQueryable<T, object>>? include = null);
    Task<Pagination<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
                                    int index = 0, int size = 10, bool enableTracking = true);
}
