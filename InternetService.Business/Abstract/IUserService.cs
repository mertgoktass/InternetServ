using DynobilV3.Core.Utilities.Results.Abstract;
using DynobilV3.Entities.Concrete;
using DynobilV3.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Business.Abstract
{
    public interface IUserService
    {
        Task<IResult> CreateUserAsync(EmployeeAddDto userAddDto);
        IDataResult<List<Personel>> GetAll();
    }
}
