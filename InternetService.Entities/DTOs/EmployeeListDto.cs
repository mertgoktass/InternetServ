using DynobilV3.Core.Entities.Abstract;
using DynobilV3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Entities.DTOs
{
    public class EmployeeListDto : IDto
    {
        public List<Personel> Users { get; set; }
    }
}
