using NLayerArchitecture.Core.Models;

namespace NLayerArchitecture.Core.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<List<Company>> GetCompanyWithCategory();
    }
}
