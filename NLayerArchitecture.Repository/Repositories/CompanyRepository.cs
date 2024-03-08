using DataHub.Repository;
using DataHub.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using NLayerArchitecture.Core.Models;
using NLayerArchitecture.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Repository.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Company>> GetCompanyWithCategory()
        {
            return await _context.Companies.Include(x => x.Category).ToListAsync();
        }
    }
}
