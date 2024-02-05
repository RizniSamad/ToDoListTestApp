using Ardalis.Specification;
using ToDoListTestApp.DTO.ToDoLists;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.ToDoLists
{
    public class GetAllToDoListsPaginationCountSpec : Specification<ToDoList>
    {
        public GetAllToDoListsPaginationCountSpec(ToDoListQueryParamsDto queryParamsDto) 
        {

        }
    }
}
