﻿using ToDoListTestApp.DTO.AppUsers;
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
        public AppUserService(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Responce<int>> CreateAppUser(AppUserCreateDto dto)
        {
            try
            {
                AppUser appUser = new()
                {
                    Email = dto.Email,
                    Password = dto.Password,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Gender = dto.Gender,
                    CreatedDate = DateTime.Now,
                };

                await _repository.AddAsync(appUser);
                var r = await _repository.SaveChangesAsync();
                if (r > 0)
                {
                    return new Responce<int>(appUser.Id,true,"Saved");
                }
                else
                {
                    List<string> errors = new()
                    {
                        "Validation error"
                    };

                    return new Responce<int>(0, false, "Failed", errors);
                }
            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<int>(0, false, "Failed", errors); ;
            }
        }

        public async Task<Responce<bool>> DeleteAppUserById(int id)
        {
            try
            {
                AppUser appUser = await _repository.GetByIdAsync(id);

                _repository.Remove(appUser);
                var r = await _repository.SaveChangesAsync();
                if (r > 0)
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

        public async Task<Responce<AppUserDto>> GetAppUserById(int id)
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

        public async Task<Responce<int>> UpdateAppUser(AppUserUpdateDto dto)
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
                    return new Responce<int>(appUser.Id, true, "Saved");
                }
                else
                {
                    List<string> errors = new()
                    {
                        "Validation error"
                    };

                    return new Responce<int>(0, false, "Failed", errors);
                }
            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<int>(0, false, "Failed", errors); ;
            }
        }
    }
}