using Ardalis.Specification;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.ToDoListTasks
{
    public class GetToDoListTaskByIdSpec : Specification<ToDoListTask>
    {
        public GetToDoListTaskByIdSpec(int id) 
        {
            Query.Where(a => a.Id == id);
            Query.Include(a => a.ToDoList);
        }
    }
}
