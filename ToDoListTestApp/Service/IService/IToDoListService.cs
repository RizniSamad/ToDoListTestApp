using ToDoListTestApp.DTO.ToDoLists;
using ToDoListTestApp.Helper;

namespace ToDoListTestApp.Service.IService
{
    public interface IToDoListService
    {
        Task<Responce<Guid>> CreateToDoList(ToDoListCreateDto dto);
        Task<Responce<Guid>> UpdateToDoList(ToDoListUpdateDto dto);
        Task<PaginatedResponce<ToDoListDto>> GetAllToDoLists(ToDoListQueryParamsDto dto);
        Task<Responce<ToDoListDto>> GetToDoListById(Guid id);
        Task<Responce<bool>> DeleteToDoListById(Guid id);
    }
}
