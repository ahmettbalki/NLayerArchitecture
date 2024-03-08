using AutoMapper;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
