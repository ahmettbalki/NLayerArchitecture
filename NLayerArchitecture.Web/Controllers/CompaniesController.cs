using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;
using NLayerArchitecture.Core.Services;

namespace NLayerArchitecture.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, ICategoryService categoryService, IMapper mapper)
        {
            _companyService = companyService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _companyService.GetCompanyWithCategory());
        }

        public async Task<IActionResult> Save()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                await _companyService.AddAsync(_mapper.Map<Company>(companyDto));
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }
    }
}
