using ToDoListTestApp.DTO.AppUsers;
using ToDoListTestApp.Helper;

namespace ToDoListTestApp.Service.IService
{
    public interface IAppUserService
    {
        Task<Responce<int>> CreateAppUser(AppUserCreateDto dto);
        Task<Responce<int>> UpdateAppUser(AppUserUpdateDto dto);
        Task<PaginatedResponce<AppUserDto>> GetAllAppUsers(AppUserQueryParamsDto dto);
        Task<Responce<AppUserDto>> GetAppUserById(int id);
        Task<Responce<bool>> DeleteAppUserById(int id);
    }
}
