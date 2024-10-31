using AutoMapper;
using Classwork.Application.DTOs;
using Classwork.Application.Services.Interfaces;
using Classwork.Domain.Entities;
using Classwork.Persistence.Services.Category;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Ecom.App.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateAsync(CategoryCreateDTO createDto)
        {
            var categoryEntity = _mapper.Map<Category>(createDto);
            var createdCategory = await _categoryRepository.CreateAsync(categoryEntity);
            return _mapper.Map<CategoryDTO>(createdCategory);
        }

        public Task<CategoryDTO> AddAsync(CategoryCreateDTO createDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDTO> DeleteAsync(int id)
        {
            var existsCategory = await _categoryRepository.GetAsync(id);

            if (existsCategory == null) throw new Exception("Not found");

            var deletedCategory = await _categoryRepository.DeleteAsync(existsCategory);

            return _mapper.Map<CategoryDTO>(deletedCategory);
        }

        public async Task<CategoryDTO?> GetAsync(int id)
        {
            var CategoryEntity = await _categoryRepository.GetAsync(id);

            if (CategoryEntity == null) throw new Exception("Not found");
            return _mapper.Map<CategoryDTO>(CategoryEntity);
        }

        public async Task<CategoryDTO?> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
        {
            var CategoryEntity = await _categoryRepository.GetAsync(predicate, include);

            if (CategoryEntity == null) throw new Exception("Not found");
            return _mapper.Map<CategoryDTO>(CategoryEntity);
        }

        public async Task<CategoryListDTO> GetListAsync(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
        {
            var CategoryListEntity = await _categoryRepository.GetListAsync(predicate, orderBy, include, index, size, enableTracking);

            if (CategoryListEntity == null) throw new Exception("Not found");
            return _mapper.Map<CategoryListDTO>(CategoryListEntity);
        }

        public async Task<CategoryDTO> UpdateAsync(int id, CategoryUpdateDTO updateDto)
        {
            var existCategory = await _categoryRepository.GetAsync(id);

            if (existCategory == null) throw new Exception("Not found");

            existCategory = _mapper.Map(updateDto, existCategory);

            var updatedCategory = await _categoryRepository.UpdateAsync(existCategory);

            return _mapper.Map<CategoryDTO>(updatedCategory);
        }
    }
}


