using ToDoListTestApp.DTO.ToDoListTasks;
using ToDoListTestApp.Helper;

namespace ToDoListTestApp.Service.IService
{
    public interface IToDoListTaskService
    {
        Task<Responce<int>> CreateToDoListTask(ToDoListTaskCreateDto dto);
        Task<Responce<int>> UpdateToDoListTask(ToDoListTaskUpdateDto dto);
        Task<PaginatedResponce<ToDoListTaskDto>> GetAllToDoListTasks(ToDoListTaskQueryParamsDto dto);
        Task<Responce<ToDoListTaskDto>> GetToDoListTaskById(int id);
        Task<Responce<bool>> DeleteToDoListTaskById(int id);
    }
}
