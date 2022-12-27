using DynobilV3.Core.Utilities.Results.Abstract;
using DynobilV3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetServices.Business.Abstract
{
    public interface IBayiService
    {
        IResult Create(Company entity);
        IResult Delete(Company entity);
        IResult Update(Company entity);
        IDataResult<List<Company>> GetAll();
        IDataResult<List<Company>> GetTheDeleted();
        IDataResult<List<Personel>> GetUser(int? id);
    }
}
