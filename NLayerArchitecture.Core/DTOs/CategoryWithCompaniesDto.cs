﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Core.DTOs
{
    public class CategoryWithCompaniesDto : CategoryDto
    {
        public List<CompanyDto> Companies { get; set; }
    }
}
