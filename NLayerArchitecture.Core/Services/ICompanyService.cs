using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Core.Services
{
    public interface ICompanyService : IService<Company>
    {
        Task<CustomResponseDto<List<CompanyWithCategoryDto>>> GetCompanyWithCategory();
    }
}
