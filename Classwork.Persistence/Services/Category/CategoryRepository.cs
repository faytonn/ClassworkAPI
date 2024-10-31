using Classwork.Domain.Entities;
using Classwork.Persistence.Context;
using Classwork.Persistence.Services.Category;

namespace Classwork.Persistence.Repositories.Implementation
{
    public class CategoryRepository : EfRepositoryBase<Category, AppDBContext>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext context) : base(context)
        {
        }
    }
}
