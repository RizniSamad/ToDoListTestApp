using ToDoListTestApp.DTO.ToDoListTasks;
using ToDoListTestApp.Helper;

namespace ToDoListTestApp.Service.IService
{
    public interface IToDoListTaskService
    {
        Task<Responce<Guid>> CreateToDoListTask(ToDoListTaskCreateDto dto);
        Task<Responce<Guid>> UpdateToDoListTask(ToDoListTaskUpdateDto dto);
        Task<PaginatedResponce<ToDoListTaskDto>> GetAllToDoListTasks(ToDoListTaskQueryParamsDto dto);
        Task<Responce<ToDoListTaskDto>> GetToDoListTaskById(Guid id);
        Task<Responce<bool>> DeleteToDoListTaskById(Guid id);
        Task<Responce<ToDoListTaskDto>> UpcommingTask(Guid guid);
    }
}
