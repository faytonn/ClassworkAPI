using AutoMapper;
using Classwork.Application.DTOs;
using Classwork.Domain.Entities;
using Classwork.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using static Classwork.Application.DTOs.ProductDTO;

namespace Classwork.Application.Services.Implementations
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> AddAsync(ProductCreateDto createDto)
        {
            var ProductEntity = _mapper.Map<Product>(createDto);
            var createdProduct = await _productRepository.AddAsync(ProductEntity);
            return _mapper.Map<ProductDTO>(createdProduct);
        }

        public async Task<ProductDTO> DeleteAsync(int id)
        {
            var existProduct = await _productRepository.GetAsync(id);

            if (existProduct == null) throw new Exception("Not found");

            var deletedProduct = await _productRepository.DeleteAsync(existProduct);

            return _mapper.Map<ProductDTO>(deletedProduct);
        }

        public async Task<ProductDTO?> GetAsync(int id)
        {
            var ProductEntity = await _productRepository.GetAsync(id);
            if (ProductEntity == null) throw new Exception("Not found");

            return _mapper.Map<ProductDTO>(ProductEntity);
        }

        public async Task<ProductDTO?> GetAsync(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
        {
            var ProductEntity = await _productRepository.GetAsync(predicate, include);

            if (ProductEntity == null) throw new Exception("Not found");

            return _mapper.Map<ProductDTO>(ProductEntity);
        }

        public async Task<ProductListDto> GetListAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
        {
            var ProductListEntity = await _productRepository.GetListAsync(predicate, orderBy, include, index, size, enableTracking);

            if (ProductListEntity == null) throw new Exception("Not found");

            return _mapper.Map<ProductListDto>(ProductListEntity);
        }

        public async Task<ProductDTO> UpdateAsync(int id, ProductUpdateDto updateDto)
        {
            var existProduct = await _productRepository.GetAsync(id);

            if (existProduct == null) throw new Exception("Not found");

            existProduct = _mapper.Map(updateDto, existProduct);

            var updatedProduct = await _productRepository.UpdateAsync(existProduct);

            return _mapper.Map<ProductDTO>(updatedProduct);
        }
    }
}
}
