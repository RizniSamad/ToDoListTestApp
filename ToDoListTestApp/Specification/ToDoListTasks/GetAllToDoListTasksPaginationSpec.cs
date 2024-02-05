using Ardalis.Specification;
using ToDoListTestApp.DTO.ToDoListTasks;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.ToDoListTasks
{
    public class GetAllToDoListTasksPaginationSpec : Specification<ToDoListTask>
    {
        public GetAllToDoListTasksPaginationSpec(ToDoListTaskQueryParamsDto queryParamsDto) 
        {

            Query.Skip(queryParamsDto.PageSize * (queryParamsDto.CurrentPage - 1)).Take(queryParamsDto.PageSize);
            Query.Include(s => s.ToDoList);
        }
    }
}
