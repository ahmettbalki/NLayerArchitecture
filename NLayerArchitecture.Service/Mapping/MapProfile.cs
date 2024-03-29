﻿using AutoMapper;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;

namespace DataHub.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CompanyFeature, CompanyFeatureDto>().ReverseMap();
            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<Company, CompanyWithCategoryDto>();
            CreateMap<Category, CategoryWithCompaniesDto>();
        }
    }
}
