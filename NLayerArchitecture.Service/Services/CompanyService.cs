using AutoMapper;
using DataHub.Service.Services;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;
using NLayerArchitecture.Core.Repositories;
using NLayerArchitecture.Core.Services;
using NLayerArchitecture.Core.UnitOfWorks;

namespace NLayerArchitecture.Service.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(IGenericRepository<Company> repository, IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyWithCategoryDto>> GetCompanyWithCategory()
        {
            var companies = await _companyRepository.GetCompanyWithCategory();

            var companiesDto = _mapper.Map<List<CompanyWithCategoryDto>>(companies);
            return companiesDto;
        }
    }
}
