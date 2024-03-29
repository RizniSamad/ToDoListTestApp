﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListTestApp.DTO.AppUsers;
using ToDoListTestApp.Helper;
using ToDoListTestApp.Service.IService;

namespace ToDoListTestApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [AllowAnonymous]
        [HttpPost("login", Name = "Login")]
        public async Task<ActionResult<Responce<TokenDto>>> Login([FromBody] LoginDto loginDto)
        {
            var result = await _appUserService.Login(loginDto);
            if (result.Success)
            {
                return result;
            }
            return BadRequest(result);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Responce<Guid>>> CreateAppUser([FromBody] AppUserCreateDto dto)
        {
            var result = await _appUserService.CreateAppUser(dto);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult<Responce<Guid>>> UpdateAppUser([FromBody] AppUserUpdateDto dto)
        {
            var resultEx = await _appUserService.GetAppUserById(dto.Id);
            if (resultEx.Success)
            {
                var result = await _appUserService.UpdateAppUser(dto);
                if (result.Success)
                {
                    return result;
                }

                return BadRequest(result);
            }

            return BadRequest(resultEx);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponce<AppUserDto>>> GetAllAppUsers([FromQuery] AppUserQueryParamsDto dto)
        {
            var result = await _appUserService.GetAllAppUsers(dto);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Responce<AppUserDto>>> GetAppUserById(Guid id)
        {
            var result = await _appUserService.GetAppUserById(id);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Responce<bool>>> DeleteAppUserById(Guid id)
        {
            var resultEx = await _appUserService.GetAppUserById(id);
            if (resultEx.Success)
            {
                var result = await _appUserService.DeleteAppUserById(id);
                if (result.Success)
                {
                    return result;
                }

                return BadRequest(result);
            }
            return BadRequest(resultEx);
        }
    }
}
