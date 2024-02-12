using Microsoft.AspNetCore.Identity;
using ToDoListTestApp.DTO.AppUsers;
using ToDoListTestApp.Entity;
using ToDoListTestApp.Helper;
using ToDoListTestApp.Repository.IRepository;
using ToDoListTestApp.Service.IService;
using ToDoListTestApp.Specification.AppUsers;

namespace ToDoListTestApp.Service
{
    public class AppUserService : IAppUserService
    {
        private readonly IRepository<AppUser> _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AppUserService(IRepository<AppUser> repository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<Responce<Guid>> CreateAppUser(AppUserCreateDto dto)
        {
            try
            {
                AppUser appUser = new()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    UserName = dto.Email,
                    EmailConfirmed = true,
                    Gender = dto.Gender,
                    CreatedDate = DateTime.Now,
                };
                var r = await _userManager.CreateAsync(appUser, dto.Password);
                if (r.Succeeded)
                {
                    return new Responce<Guid>(appUser.Id,true,"Saved");
                }
                else
                {
                    List<string> errors = new()
                    {
                        "Validation error"
                    };

                    return new Responce<Guid>(Guid.Empty, false, "Failed", errors);
                }
            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<Guid>(Guid.Empty, false, "Failed", errors); ;
            }
        }

        public async Task<Responce<bool>> DeleteAppUserById(Guid id)
        {
            try
            {
                AppUser appUser = await _repository.GetByIdAsync(id);
                var r = await _userManager.DeleteAsync(appUser);
                if (r.Succeeded)
                {
                    return new Responce<bool>(true, true, "Saved");
                }
                else
                {
                    List<string> errors = new()
                    {
                        "Validation error"
                    };

                    return new Responce<bool>(false, false, "Failed", errors);
                }
            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<bool>(false, false, "Failed", errors); ;
            }
        }

        public async Task<PaginatedResponce<AppUserDto>> GetAllAppUsers(AppUserQueryParamsDto dto)
        {
            var spec = new GetAllAppUsersPaginationSpec(dto);
            var specCount = new GetAllAppUsersPaginationCountSpec(dto);

            var data = await _repository.GetAllAsync(spec);
            var count = await _repository.CountAsync(specCount);

            var items = data.Select(s => new AppUserDto()
            {
                Id = s.Id,
                Email = s.Email,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Gender = s.Gender.ToString()
            }).ToList();

            return new PaginatedResponce<AppUserDto>(items, count, dto.CurrentPage, dto.PageSize, true);
        }

        public async Task<Responce<AppUserDto>> GetAppUserById(Guid id)
        {
            try
            {
                var spec = new GetAppUserByIdSpec(id); ;
                AppUser appUser = await _repository.GetFirstOrDefaultAsync(spec);
                if (appUser == null)
                {
                    List<string> errors = new()
                    {
                        "Not found"
                    };

                    return new Responce<AppUserDto>(null, false, "Failed", errors);
                }

                AppUserDto appUserDto = new()
                {
                    Id = id,
                    Email = appUser.Email,
                    FirstName = appUser.FirstName,  
                    LastName = appUser.LastName,
                    Gender = appUser.Gender.ToString(),
                };

                if (appUser != null)
                {
                    return new Responce<AppUserDto>(appUserDto, true, "Saved");
                }
                else
                {
                    List<string> errors = new()
                    {
                        "Validation error"
                    };

                    return new Responce<AppUserDto>(null, false, "Failed", errors);
                }
            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<AppUserDto>(null, false, "Failed", errors); ;
            }
        }

        public async Task<Responce<Guid>> UpdateAppUser(AppUserUpdateDto dto)
        {
            try
            {
                AppUser appUser = await _repository.GetByIdAsync(dto.Id);
                appUser.FirstName = dto.FirstName;
                appUser.LastName = dto.LastName;
                appUser.Gender = dto.Gender;

                _repository.Update(appUser);
                var r = await _repository.SaveChangesAsync();
                if (r > 0)
                {
                    return new Responce<Guid>(appUser.Id, true, "Saved");
                }
                else
                {
                    List<string> errors = new()
                    {
                        "Validation error"
                    };

                    return new Responce<Guid>(Guid.Empty, false, "Failed", errors);
                }
            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<Guid>(Guid.Empty, false, "Failed", errors); ;
            }
        }

        public async Task<Responce<TokenDto>> Login(LoginDto loginDto)
        {
            try
            {
                var spec = new UserByEmailSpec(loginDto.Email);
                var user = await _repository.GetFirstOrDefaultAsync(spec);

                if (user == null)
                {
                    List<string> errors = new()
                    {
                        "User name or password is incorrect"
                    };

                    return new Responce<TokenDto>(new(), false, "Failed", errors);
                }

                var result = await _signInManager.CheckPasswordSignInAsync(
                     user,
                     loginDto.Password,
                     false
                 );

                if (result == null)
                {
                    List<string> errors = new()
                    {
                        "User name or password is incorrect"
                    };

                    return new Responce<TokenDto>(new(), false, "Failed", errors);
                }


                var token = _tokenService.CreateToken(user);
                if (!token.Success)
                {
                    return new Responce<TokenDto>(token.Data, token.Success, token.Message, token.Errors);

                }
                return new Responce<TokenDto>(token.Data, true, token.Message);
            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<TokenDto>(new(), false, "Failed", errors); ;
            }
        }
    }
}
