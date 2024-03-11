namespace NLayerArchitecture.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
