using AutoMapper;
using DataHub.Service.Services;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;
using NLayerArchitecture.Core.Repositories;
using NLayerArchitecture.Core.Services;
using NLayerArchitecture.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Service.Services
{
    public class CompanyServiceWithNoCaching : Service<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyServiceWithNoCaching(IGenericRepository<Company> repository, IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CompanyWithCategoryDto>>> GetCompanyWithCategory()
        {
            var companies = await _companyRepository.GetCompanyWithCategory();

            var companiesDto = _mapper.Map<List<CompanyWithCategoryDto>>(companies);
            return CustomResponseDto<List<CompanyWithCategoryDto>>.Success(200, companiesDto);
        }
    }
}
