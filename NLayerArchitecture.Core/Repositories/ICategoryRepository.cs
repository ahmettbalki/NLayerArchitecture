using NLayerArchitecture.Core.Models;

namespace NLayerArchitecture.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithCompaniesAsync(int categoryId);
    }
}
