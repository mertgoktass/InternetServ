using DynobilV3.Business.Abstract;
using DynobilV3.Business.Utilities;
using DynobilV3.Core.Utilities.Results.Abstract;
using DynobilV3.Core.Utilities.Results.Concrete;
using DynobilV3.DataAccess.Abstract;
using DynobilV3.Entities.Concrete;
using DynobilV3.Entities.DTOs;
using InternetServices.Business.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Business.Concrete
{
    public class BayiManager : IBayiService
    {
        private readonly IBayiDal _bayiDal;
        private readonly IUserService _userService;
        public BayiManager(IBayiDal bayiDal, UserManager<Personel> userManager, IUserService userService)
        {
            _bayiDal = bayiDal;
            _userService = userService;
        }
        
        public IResult Create(Company entity)
        {
            if (entity != null)
            {
                var val = _bayiDal.Create(entity);
                return new SuccessResult(Messages.AddingCompleted);
            }
            return new ErrorResult(Messages.AddingNotCompleted);
        }

        public IResult Delete(Company entity)
        {
            if (entity != null)
            {
                _bayiDal.Delete(entity);
                return new SuccessResult(Messages.DeletingCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<Company>> GetAll()
        {
            var entities = _bayiDal.GetAll(b => b.IsActive == true);

            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<Company>>(entities, Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<Company>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<Company>>(Messages.ListingNotCompleted);
        }
        public IDataResult<Company> GetById(int? id)
        {
            if (id != null)
            {
                var entity = _bayiDal.Get(b => b.Id == (int)id);
                if (entity != null)
                {
                    return new SuccessDataResult<Company>(entity, Messages.GettingCompleted);
                }
                return new ErrorDataResult<Company>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<Company>(Messages.GettingNotCompleted);
        }


        public IDataResult<List<Company>> GetTheDeleted()
        {
            var entities = _bayiDal.GetAll(b => b.IsActive == false);
            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<Company>>(entities, Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<Company>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<Company>>(Messages.ListingNotCompleted);
        }

        public IDataResult<List<Personel>> GetUser(int? id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Company entity)
        {
            if (entity != null)
            {
                _bayiDal.Update(entity);
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }
    }
}
