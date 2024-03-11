using AutoMapper;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;
using NLayerArchitecture.Core.Services;
using Microsoft.AspNetCore.Mvc;
using NLayerArchitecture.API.Filters;

namespace DataHub.API.Controllers
{
    [ValidateFilterAttribute]
    public class CompaniesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompaniesController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpGet("action")]
        public async Task<IActionResult> GetCompaniesWithCategory()
        {
            return CreateActionResult(await _companyService.GetCompanyWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var companies = await _companyService.GetAllAsync();
            var companiesDtos = _mapper.Map<List<CompanyDto>>(companies.ToList());
            return CreateActionResult(CustomResponseDto<List<CompanyDto>>.Success(200, companiesDtos)); 
        }

        [ServiceFilter(typeof(NotFoundFilter<Company>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            var companiesDto = _mapper.Map<CompanyDto>(company);
            return CreateActionResult(CustomResponseDto<CompanyDto>.Success(200, companiesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CompanyDto companyDto)
        {
            var company = await _companyService.AddAsync(_mapper.Map<Company>(companyDto));
            var companiesDto = _mapper.Map<CompanyDto>(company);
            return CreateActionResult(CustomResponseDto<CompanyDto>.Success(200, companiesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyUpdateDto companyDto)
        {
            await _companyService.UpdateAsync(_mapper.Map<Company>(companyDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            await _companyService.RemoveAsync(company);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
