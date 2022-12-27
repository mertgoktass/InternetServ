using DynobilV3.Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Entities.Concrete
{
    public class Personel : IdentityUser , IEntity  //IdentityUser ile hazir sutunlar geliyor zaten.Ustune kendimiz yeni sutunlar iyoruz
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string SigningDate { get; set; }
        public string Salary { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
