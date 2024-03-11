using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;

namespace NLayerArchitecture.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithCompaniesDto>> GetSingleCategoryByIdWithCompaniesAsync(int categoryId);
    }
}
