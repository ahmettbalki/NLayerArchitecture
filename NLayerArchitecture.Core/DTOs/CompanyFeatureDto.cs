using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Core.DTOs
{
    public class CompanyFeatureDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public int CompanyId { get; set; }
    }
}
