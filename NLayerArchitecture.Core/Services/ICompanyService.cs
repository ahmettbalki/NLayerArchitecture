using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;

namespace NLayerArchitecture.Core.Services
{
    public interface ICompanyService : IService<Company>
    {
        Task<List<CompanyWithCategoryDto>> GetCompanyWithCategory();
    }
}
