using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListTestApp.DTO.AppUsers;
using ToDoListTestApp.Helper;
using ToDoListTestApp.Service.IService;

namespace ToDoListTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost]
        public async Task<ActionResult<Responce<int>>> CreateAppUser([FromBody] AppUserCreateDto dto)
        {
            var result = await _appUserService.CreateAppUser(dto);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult<Responce<int>>> UpdateAppUser([FromBody] AppUserUpdateDto dto)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Responce<AppUserDto>>> GetAppUserById(int id)
        {
            var result = await _appUserService.GetAppUserById(id);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Responce<bool>>> DeleteAppUserById(int id)
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
