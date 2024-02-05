using ToDoListTestApp.DTO.ToDoLists;
using ToDoListTestApp.Helper;

namespace ToDoListTestApp.Service.IService
{
    public interface IToDoListService
    {
        Task<Responce<int>> CreateToDoList(ToDoListCreateDto dto);
        Task<Responce<int>> UpdateToDoList(ToDoListUpdateDto dto);
        Task<PaginatedResponce<ToDoListDto>> GetAllToDoLists(ToDoListQueryParamsDto dto);
        Task<Responce<ToDoListDto>> GetToDoListById(int id);
        Task<Responce<bool>> DeleteToDoListById(int id);
    }
}
