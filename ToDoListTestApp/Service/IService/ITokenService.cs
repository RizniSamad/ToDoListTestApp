using System.Security.Claims;
using ToDoListTestApp.DTO.AppUsers;
using ToDoListTestApp.Entity;
using ToDoListTestApp.Helper;

namespace ToDoListTestApp.Service.IService
{
    public interface ITokenService
    {
        Responce<TokenDto> CreateToken(AppUser user, TokenDto tokenDto = null);
    }
}
