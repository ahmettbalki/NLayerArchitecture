using DataHub.Repository;
using DataHub.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using NLayerArchitecture.Core.Models;
using NLayerArchitecture.Core.Repositories;

namespace NLayerArchitecture.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithCompaniesAsync(int categoryId)
        {
            return await _context.Categories.Include(x => x.Companies).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
