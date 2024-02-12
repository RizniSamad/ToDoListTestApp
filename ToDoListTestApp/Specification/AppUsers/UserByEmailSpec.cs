using Ardalis.Specification;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.AppUsers
{
    public class UserByEmailSpec : Specification<AppUser>
    {
        public UserByEmailSpec(string email) 
        {
            Query.Where(a => a.Email == email);
        }
    }
}
