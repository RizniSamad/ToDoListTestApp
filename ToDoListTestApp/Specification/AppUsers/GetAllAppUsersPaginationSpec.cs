using Ardalis.Specification;
using ToDoListTestApp.DTO.AppUsers;
using ToDoListTestApp.Entity;

namespace ToDoListTestApp.Specification.AppUsers
{
    public class GetAllAppUsersPaginationSpec : Specification<AppUser>
    {
        public GetAllAppUsersPaginationSpec(AppUserQueryParamsDto queryParamsDto) 
        {

            Query.Skip(queryParamsDto.PageSize * (queryParamsDto.CurrentPage - 1)).Take(queryParamsDto.PageSize);
        }
    }
}
