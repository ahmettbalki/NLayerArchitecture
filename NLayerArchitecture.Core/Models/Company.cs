namespace NLayerArchitecture.Core.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public DateTime FoundedData { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public CompanyFeature CompanyFeature { get; set; }
    }
}
