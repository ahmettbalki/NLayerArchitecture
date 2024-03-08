using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Core.DTOs
{
    public class CompanyDto : BaseDto
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public DateTime FoundedData { get; set; }
        public int CategoryId { get; set; }
    }
}
