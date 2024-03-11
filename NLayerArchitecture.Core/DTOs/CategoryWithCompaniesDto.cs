namespace NLayerArchitecture.Core.DTOs
{
    public class CategoryWithCompaniesDto : CategoryDto
    {
        public List<CompanyDto> Companies { get; set; }
    }
}
