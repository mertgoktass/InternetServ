using DynobilV3.Core.DataAccess.EntityFrameworkCore;
using DynobilV3.DataAccess.Abstract;
using DynobilV3.DataAccess.Concrete.Contexts;
using DynobilV3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfCoreBayiDal : EfCoreEntityRepository<Company> , IBayiDal
    {
        public EfCoreBayiDal(BaseContext context) : base(context)
        {

        }
    }
}
