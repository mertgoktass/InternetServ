using DynobilV3.Core.Entities.Abstract;
using DynobilV3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Entities.DTOs
{
    public class CompanyListDto : IDto
    {
        public List<Company> Company { get; set; }
    }
}
