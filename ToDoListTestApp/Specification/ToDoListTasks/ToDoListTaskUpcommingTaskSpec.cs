using Ardalis.Specification;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.ToDoListTasks
{
    public class ToDoListTaskUpcommingTaskSpec : Specification<ToDoListTask>
    {
        public ToDoListTaskUpcommingTaskSpec(Guid guid) 
        {
            Query.Where(s => s.ToDoList.UserId == guid && s.StartDate.Date == DateTime.Now.Date);
            Query.OrderBy(s => s.StartDate.Date);
            Query.Include(i => i.ToDoList);
            Query.AsSplitQuery();
        }
    }
}
