using Classwork.Application.DTOs;
using Classwork.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using static Classwork.Application.DTOs.ProductDTO;

namespace Classwork.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO?> GetAsync(int id);

        Task<ProductDTO?> GetAsync(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null);

        Task<ProductListDto> GetListAsync(Expression<Func<Product, bool>>? predicate = null,
                                        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
                                        Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null,
                                        int index = 0, int size = 10, bool enableTracking = true);

        Task<ProductDTO> AddAsync(ProductCreateDto createDto);
        Task<ProductDTO> UpdateAsync(int id, ProductUpdateDto updateDto);
        Task<ProductDTO> DeleteAsync(int id);
    }
}
