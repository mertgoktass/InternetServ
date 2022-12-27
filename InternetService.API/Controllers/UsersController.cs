
using DynobilV3.Business.Abstract;
using DynobilV3.Business.Utilities;
using DynobilV3.Core.Utilities.Results.Concrete;
using DynobilV3.Entities.Concrete;
using DynobilV3.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace DynobilV3.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<Personel> _userManager;
        public UsersController(IUserService userService, UserManager<Personel> userManager = null)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Personel Oluşturma")]
        public async Task<IActionResult> CreateUser(EmployeeAddDto userAddDto)
        {
            var result = await _userService.CreateUserAsync(userAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
