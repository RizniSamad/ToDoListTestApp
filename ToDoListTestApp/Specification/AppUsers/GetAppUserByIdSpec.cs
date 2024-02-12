using Ardalis.Specification;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.AppUsers
{
    public class GetAppUserByIdSpec : Specification<AppUser>
    {
        public GetAppUserByIdSpec(Guid id) 
        {
            Query.Where(a => a.Id == id);
        }
    }
}
