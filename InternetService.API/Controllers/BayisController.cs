using AutoMapper;
using DynobilV3.Business.Abstract;
using DynobilV3.Business.Utilities;
using DynobilV3.Core.Utilities.Results.Abstract;
using DynobilV3.Entities.Concrete;
using DynobilV3.Entities.DTOs;
using InternetServices.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynobilV3.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BayisController : ControllerBase
    {
        private readonly IBayiService _bayiService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public BayisController(IBayiService bayiService, IMapper mapper, IUserService userService)
        {
            _bayiService = bayiService;
            _mapper = mapper;
            _userService = userService;
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Bayi Görüntüleme")]
        public IActionResult GetById(int id)
        {
            var result = _bayiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
       // [Authorize(Roles = "Bayi Görüntüleme")]
        public IActionResult GetAll()
        { 
                var result = _bayiService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
        }
        [HttpGet]
        [Authorize(Roles = "Bayi Görüntüleme")]
        public IActionResult GetAllDeleted()
        {
            var result = _bayiService.GetTheDeleted();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        [Authorize(Roles = "Bayi Ekleme")]
        public IActionResult Create(BayiAddDto bayiAddDto)
        {
            var result = _bayiService.Create(_mapper.Map<Bayi>(bayiAddDto));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("{id}")]
        [Authorize(Roles = "Bayi Düzenleme")]
        public IActionResult Update(int id, BayiUpdateDto bayiUpdateDto)
        {
            if (id != bayiUpdateDto.Id)
            {
                return BadRequest();
            }

            var result = _bayiService.Update(_mapper.Map<Bayi>(bayiUpdateDto));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("{id}")]
        [Authorize(Roles = "Bayi Silme")]
        public IActionResult Delete(int id)
        {
            var existToEntity = _bayiService.GetById(id).Data;
            existToEntity.IsActive = false;

            var result = _bayiService.Update(existToEntity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("{id}")]
        [Authorize(Roles = "Bayi Silme")]
        public IActionResult UndoDelete(int id)
        {
            var existToEntity = _bayiService.GetById(id).Data;
            existToEntity.IsActive = true;

            var result = _bayiService.Update(existToEntity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        } 
        [HttpGet]
        [Authorize(Roles = "Bakiyeleri Görme")]
        public IActionResult GetDealerBalances()
        {
            var result = _bayiService.GetAllDealerBalances(HttpContext.User.Identity.Name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("{id}")]
        [Authorize(Roles = "Bayi Silme")]
        public IActionResult HardDelete(int id)
        {
            var result = _bayiService.Delete(_bayiService.GetById(id).Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
