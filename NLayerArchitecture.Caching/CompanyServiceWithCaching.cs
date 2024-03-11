using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;
using NLayerArchitecture.Core.Repositories;
using NLayerArchitecture.Core.Services;
using NLayerArchitecture.Core.UnitOfWorks;
using System.Linq.Expressions;

namespace NLayerArchitecture.Caching
{
    public class CompanyServiceWithCaching : ICompanyService
    {
        private const string CacheCompanyKey = "companiesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyServiceWithCaching(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheCompanyKey, out _))
            {
                _memoryCache.Set(CacheCompanyKey, _companyRepository.GetCompanyWithCategory().Result);
            }
        }

        public async Task<Company> AddAsync(Company entity)
        {
            await _companyRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            CacheAllCompaniesAsync();
            return entity;
        }

        public async Task<IEnumerable<Company>> AddRangeAsync(IEnumerable<Company> entities)
        {
            await _companyRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            CacheAllCompaniesAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Company, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = _memoryCache.Get<IEnumerable<Company>>(CacheCompanyKey);
            return Task.FromResult(companies);
        }

        public Task<Company> GetByIdAsync(int id)
        {
            var company = _memoryCache.Get<List<Company>>(CacheCompanyKey).FirstOrDefault(x => x.Id == id);
            if (company == null)
            {
                throw new DirectoryNotFoundException($"{typeof(Company).Name}({id}) not found");
            }
            return Task.FromResult(company);
        }

        public Task<List<CompanyWithCategoryDto>> GetCompanyWithCategory()
        {
            var companies = _memoryCache.Get<IEnumerable<Company>>(CacheCompanyKey);
            var companiesWithCategoryDto = _mapper.Map<List<CompanyWithCategoryDto>>(companies);
            return Task.FromResult(companiesWithCategoryDto);
        }

        public async Task RemoveAsync(Company entity)
        {
            _companyRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCompaniesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Company> entities)
        {
            _companyRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCompaniesAsync();
        }

        public async Task UpdateAsync(Company entity)
        {
            _companyRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCompaniesAsync();
        }

        public IQueryable<Company> Where(Expression<Func<Company, bool>> expression)
        {
            return _memoryCache.Get<List<Company>>(CacheCompanyKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllCompaniesAsync()
        {
            _memoryCache.Set(CacheCompanyKey, await _companyRepository.GetAll().ToListAsync());
        }
    }
}
