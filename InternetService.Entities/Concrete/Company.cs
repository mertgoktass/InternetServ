using DynobilV3.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Entities.Concrete
{
    public class Company : EntityBase , IEntity
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Personel> Personels { get; set; }

    }
}
