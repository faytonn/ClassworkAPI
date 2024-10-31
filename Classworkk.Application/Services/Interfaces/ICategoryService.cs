using Classwork.Application.DTOs;
using Classwork.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Classwork.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO?> GetAsync(int id);

        Task<CategoryDTO?> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null);

        Task<CategoryListDTO> GetListAsync(Expression<Func<Category, bool>>? predicate = null,
                                        Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
                                        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
                                        int index = 0, int size = 10, bool enableTracking = true);

        Task<CategoryDTO> AddAsync(CategoryCreateDTO createDto);
        Task<CategoryDTO> UpdateAsync(int id, CategoryUpdateDTO updateDto);
        Task<CategoryDTO> DeleteAsync(int id);
    }
}
