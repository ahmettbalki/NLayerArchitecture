using AutoMapper;
using DataHub.Service.Services;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;
using NLayerArchitecture.Core.Repositories;
using NLayerArchitecture.Core.Services;
using NLayerArchitecture.Core.UnitOfWorks;

namespace NLayerArchitecture.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithCompaniesDto>> GetSingleCategoryByIdWithCompaniesAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithCompaniesAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryWithCompaniesDto>(category);
            return CustomResponseDto<CategoryWithCompaniesDto>.Success(200, categoryDto);
        }
    }
}
