using Microsoft.AspNetCore.Mvc;
using ToDoListTestApp.DTO.ToDoLists;
using ToDoListTestApp.Helper;
using ToDoListTestApp.Service;
using ToDoListTestApp.Service.IService;

namespace ToDoListTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpPost]
        public async Task<ActionResult<Responce<Guid>>> CreateToDoList([FromBody] ToDoListCreateDto dto)
        {
            var result = await _toDoListService.CreateToDoList(dto);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult<Responce<Guid>>> UpdateToDoList([FromBody] ToDoListUpdateDto dto)
        {
            var resultEx = await _toDoListService.GetToDoListById(dto.Id);
            if (resultEx.Success)
            {
                var result = await _toDoListService.UpdateToDoList(dto);
                if (result.Success)
                {
                    return result;
                }

                return BadRequest(result);
            }

            return BadRequest(resultEx);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponce<ToDoListDto>>> GetAllToDoLists([FromQuery] ToDoListQueryParamsDto dto)
        {
            var result = await _toDoListService.GetAllToDoLists(dto);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Responce<ToDoListDto>>> GetToDoListById(Guid id)
        {
            var result = await _toDoListService.GetToDoListById(id);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Responce<bool>>> DeleteToDoListById(Guid id)
        {
            var resultEx = await _toDoListService.GetToDoListById(id);
            if (resultEx.Success)
            {
                var result = await _toDoListService.DeleteToDoListById(id);
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
