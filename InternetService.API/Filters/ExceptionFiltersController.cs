using AutoMapper;
using DynobilV3.API.Controllers;
using DynobilV3.Business.Abstract;
using DynobilV3.Business.Concrete;
using DynobilV3.Business.Utilities;
using DynobilV3.Core.Entities.Concrete;
using DynobilV3.Core.Utilities.Results.Concrete;
using DynobilV3.DataAccess.Concrete.Contexts;
using DynobilV3.DataAccess.Concrete.EntityFrameworkCore;
using DynobilV3.Entities.Concrete;
using DynobilV3.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DynobilV3.API.Filters
{
    [Authorize]
    public class ExceptionFiltersController : ControllerBase , IExceptionFilter
    {
        private readonly IHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ExceptionFiltersController(IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnException(ExceptionContext context)
        {
            if (_environment.IsProduction()) //Yayina alirken isProduction olmali
            {
                context.ExceptionHandled = true;

                var errorModel = new ErrorModel();

                switch (context.Exception)
                {
                    case SqlNullValueException:
                        errorModel.Message = "Veritabanı Hatası";
                        errorModel.Detail = context.Exception.Message;
                        break;

                    case NullReferenceException:
                        errorModel.Message = "Boş Veri";
                        errorModel.Detail = context.Exception.Message;
                        break;

                    default:
                        errorModel.Message = "Un Expection";
                        errorModel.Detail = context.Exception.Message;
                        break;
                }   
                context.Result = BadRequest(new ErrorResult("Oldu Bil"));
            }
        }
    }
}













//DbContextOptionsBuilder<BaseContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<BaseContext>();
                //dbContextOptionsBuilder.UseNpgsql("Host = localhost; Database = DynobilV3; Username = postgres; Password = Postgre_ts61");

                //LogsController logger = new LogsController(_loggerService, _mapper, new UserService(_userManager, _roleManager));
                //IActionResult result = logger.Create(new LogAddDto
                //{
                //    Icerik = errorModel.Message + " " +errorModel.Detail,
                //    PersonelId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                //    IpAdresi = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString()
                //});