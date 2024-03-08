using DataHub.API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerArchitecture.Core.Services;

namespace NLayerArchitecture.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithCompanies(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithCompaniesAsync(categoryId));
        }
    }
}
