using DynobilV3.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Entities.DTOs
{
    public class EmployeeAddDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string SigningDate { get; set; }
        public string Salary { get; set; }
        public int? CompanyId { get; set; }

    }
}
