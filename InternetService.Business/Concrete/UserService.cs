using DynobilV3.Business.Abstract;
using DynobilV3.Business.Utilities;
using DynobilV3.Core.Utilities.Results.Abstract;
using DynobilV3.Core.Utilities.Results.Concrete;
using DynobilV3.DataAccess.Abstract;
using DynobilV3.Entities.Concrete;
using DynobilV3.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DynobilV3.Business.Concrete
{
    public class UserService : IUserService  //Manager olarak isim verecektik ama identity'deki isimle karisacakti o yuzden service olarak verdik
    {
        private readonly UserManager<Personel> _userManager;
         
        public UserService(UserManager<Personel> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IResult> CreateUserAsync(EmployeeAddDto userAddDto)
        {
            var uniqueUsername = _userManager.Users.Any(u => u.UserName == userAddDto.FirstName);
            if (!uniqueUsername)  //yani kullanici adi daha once veritabaninda yok ise(essız bir username olmasi gerekir)
            {
                var user = new Personel
                {
                  FirstName = userAddDto.FirstName,
                  LastName = userAddDto.LastName,
                  DOB = userAddDto.DOB,
                    SigningDate = userAddDto.SigningDate,
                    Salary = userAddDto.Salary,
                    CompanyId = userAddDto.CompanyId
                };

                var result = await _userManager.CreateAsync(user);
                return new SuccessResult(Messages.AddingCompleted);    
            }
            return new ErrorResult(Messages.AddingNotCompleted);
        }

        public IDataResult<List<Personel>> GetAll()
        {
            var users = _userManager.Users.ToList();
            if (users != null)
            {
                return new SuccessDataResult<List<Personel>>(users, Messages.ListingCompleted);
            }
            return new ErrorDataResult<List<Personel>>(Messages.ListingNotCompleted);
        }



    }
}
