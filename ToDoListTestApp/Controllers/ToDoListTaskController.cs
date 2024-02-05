using Microsoft.AspNetCore.Mvc;
using ToDoListTestApp.DTO.ToDoListTasks;
using ToDoListTestApp.Helper;
using ToDoListTestApp.Service;
using ToDoListTestApp.Service.IService;

namespace ToDoListTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListTaskController : ControllerBase
    {
        private readonly IToDoListTaskService _toDoListTaskService;

        public ToDoListTaskController(IToDoListTaskService toDoListTaskService)
        {
            _toDoListTaskService = toDoListTaskService;
        }

        [HttpPost]
        public async Task<ActionResult<Responce<int>>> CreateToDoListTask([FromBody] ToDoListTaskCreateDto dto)
        {
            var result = await _toDoListTaskService.CreateToDoListTask(dto);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult<Responce<int>>> UpdateToDoListTask([FromBody] ToDoListTaskUpdateDto dto)
        {
            var resultEx = await _toDoListTaskService.GetToDoListTaskById(dto.Id);
            if (resultEx.Success)
            {
                var result = await _toDoListTaskService.UpdateToDoListTask(dto);
                if (result.Success)
                {
                    return result;
                }

                return BadRequest(result);
            }

            return BadRequest(resultEx);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponce<ToDoListTaskDto>>> GetAllToDoListTasks([FromQuery] ToDoListTaskQueryParamsDto dto)
        {
            var result = await _toDoListTaskService.GetAllToDoListTasks(dto);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Responce<ToDoListTaskDto>>> GetToDoListTaskById(int id)
        {
            var result = await _toDoListTaskService.GetToDoListTaskById(id);
            if (result.Success)
            {
                return result;
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Responce<bool>>> DeleteToDoListTaskById(int id)
        {
            var resultEx = await _toDoListTaskService.GetToDoListTaskById(id);
            if (resultEx.Success)
            {

                var result = await _toDoListTaskService.DeleteToDoListTaskById(id);
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
