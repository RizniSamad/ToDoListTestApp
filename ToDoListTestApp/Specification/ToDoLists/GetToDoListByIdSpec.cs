using Ardalis.Specification;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.ToDoLists
{
    public class GetToDoListByIdSpec : Specification<ToDoList>
    {
        public GetToDoListByIdSpec(int id) 
        {
            Query.Where(a => a.Id == id);
            Query.Include(s => s.User);
        }
    }
}
