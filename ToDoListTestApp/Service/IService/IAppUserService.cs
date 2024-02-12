using ToDoListTestApp.DTO.AppUsers;
using ToDoListTestApp.Helper;

namespace ToDoListTestApp.Service.IService
{
    public interface IAppUserService
    {
        Task<Responce<TokenDto>> Login(LoginDto loginDto);
        Task<Responce<Guid>> CreateAppUser(AppUserCreateDto dto);
        Task<Responce<Guid>> UpdateAppUser(AppUserUpdateDto dto);
        Task<PaginatedResponce<AppUserDto>> GetAllAppUsers(AppUserQueryParamsDto dto);
        Task<Responce<AppUserDto>> GetAppUserById(Guid id);
        Task<Responce<bool>> DeleteAppUserById(Guid id);
    }
}
