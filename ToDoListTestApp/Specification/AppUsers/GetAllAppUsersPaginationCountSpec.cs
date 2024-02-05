using Ardalis.Specification;
using ToDoListTestApp.DTO.AppUsers;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.AppUsers
{
    public class GetAllAppUsersPaginationCountSpec : Specification<AppUser>
    {
        public GetAllAppUsersPaginationCountSpec(AppUserQueryParamsDto queryParamsDto) 
        {

        }
    }
}
