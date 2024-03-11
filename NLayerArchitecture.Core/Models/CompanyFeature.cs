namespace NLayerArchitecture.Core.Models
{
    public class CompanyFeature
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
