using Ardalis.Specification;
using ToDoListTestApp.DTO.ToDoListTasks;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.ToDoListTasks
{
    public class GetAllToDoListTasksPaginationCountSpec : Specification<ToDoListTask>
    {
        public GetAllToDoListTasksPaginationCountSpec(ToDoListTaskQueryParamsDto queryParamsDto) 
        {

        }
    }
}
