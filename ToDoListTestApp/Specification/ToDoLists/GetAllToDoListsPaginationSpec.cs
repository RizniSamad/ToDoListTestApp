using Ardalis.Specification;
using ToDoListTestApp.DTO.ToDoLists;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.ToDoLists
{
    public class GetAllToDoListsPaginationSpec : Specification<ToDoList>
    {
        public GetAllToDoListsPaginationSpec(ToDoListQueryParamsDto queryParamsDto) 
        {

            Query.Skip(queryParamsDto.PageSize * (queryParamsDto.CurrentPage - 1)).Take(queryParamsDto.PageSize);
            Query.Include(s => s.User);
        }
    }
}
