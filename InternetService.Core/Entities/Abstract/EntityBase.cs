using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Core.Entities.Abstract
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}
