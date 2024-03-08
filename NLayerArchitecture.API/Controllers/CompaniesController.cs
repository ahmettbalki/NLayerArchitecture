using AutoMapper;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;
using NLayerArchitecture.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Company> _service;

        public CompaniesController(IService<Company> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var companies = await _service.GetAllAsync();
            var companiesDtos = _mapper.Map<List<CompanyDto>>(companies.ToList());
            return CreateActionResult(CustomResponseDto<List<CompanyDto>>.Success(200, companiesDtos)); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _service.GetByIdAsync(id);
            var companiesDto = _mapper.Map<CompanyDto>(company);
            return CreateActionResult(CustomResponseDto<CompanyDto>.Success(200, companiesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CompanyDto companyDto)
        {
            var company = await _service.AddAsync(_mapper.Map<Company>(companyDto));
            var companiesDto = _mapper.Map<CompanyDto>(company);
            return CreateActionResult(CustomResponseDto<CompanyDto>.Success(200, companiesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyUpdateDto companyDto)
        {
            await _service.UpdateAsync(_mapper.Map<Company>(companyDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var company = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(company);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
