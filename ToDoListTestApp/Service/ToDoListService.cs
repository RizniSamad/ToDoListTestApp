using ToDoListTestApp.DTO.ToDoLists;
using ToDoListTestApp.Entity;
using ToDoListTestApp.Helper;
using ToDoListTestApp.Repository.IRepository;
using ToDoListTestApp.Service.IService;
using ToDoListTestApp.Specification.ToDoLists;

namespace ToDoListTestApp.Service
{
    public class ToDoListService : IToDoListService
    {
        private readonly IRepository<ToDoList> _repository;
        public ToDoListService(IRepository<ToDoList> repository)
        {
            _repository = repository;
        }

        public async Task<Responce<int>> CreateToDoList(ToDoListCreateDto dto)
        {
            try
            {
                ToDoList toDoList = new()
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    UserId = dto.UserId,
                    CreatedDate = DateTime.Now,
                };

                await _repository.AddAsync(toDoList);
                var r = await _repository.SaveChangesAsync();
                if (r > 0)
                {
                    return new Responce<int>(toDoList.Id, true, "Saved");
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

        public async Task<Responce<bool>> DeleteToDoListById(int id)
        {
            try
            {
                ToDoList toDoList = await _repository.GetByIdAsync(id);

                _repository.Remove(toDoList);
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

        public async Task<PaginatedResponce<ToDoListDto>> GetAllToDoLists(ToDoListQueryParamsDto dto)
        {
            var spec = new GetAllToDoListsPaginationSpec(dto);
            var specCount = new GetAllToDoListsPaginationCountSpec(dto);

            var data = await _repository.GetAllAsync(spec);
            var count = await _repository.CountAsync(specCount);

            var items = data.Select(s => new ToDoListDto()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                AppUser = s.User.FirstName + " " + s.User.LastName,
                AppUserId = s.User.Id,
            }).ToList();

            return new PaginatedResponce<ToDoListDto>(items, count, dto.CurrentPage, dto.PageSize, true);
        }

        public async Task<Responce<ToDoListDto>> GetToDoListById(int id)
        {
            try
            {
                var spec = new GetToDoListByIdSpec(id); ;
                ToDoList toDoList = await _repository.GetFirstOrDefaultAsync(spec);
                if (toDoList == null)
                {
                    List<string> errors = new()
                    {
                        "Not found"
                    };

                    return new Responce<ToDoListDto>(null, false, "Failed", errors);
                }
                ToDoListDto toDoListDto = new()
                {
                    Id = id,
                    Name = toDoList.Name,
                    Description = toDoList.Description,
                    AppUser = toDoList.User.FirstName + " " + toDoList.User.LastName,
                    AppUserId = toDoList.User.Id,
                };

                if (toDoList != null)
                {
                    return new Responce<ToDoListDto>(toDoListDto, true, "Saved");
                }
                else
                {
                    List<string> errors = new()
                    {
                        "Validation error"
                    };

                    return new Responce<ToDoListDto>(null, false, "Failed", errors);
                }
            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<ToDoListDto>(null, false, "Failed", errors); ;
            }
        }

        public async Task<Responce<int>> UpdateToDoList(ToDoListUpdateDto dto)
        {
            try
            {
                ToDoList toDoList = await _repository.GetByIdAsync(dto.Id);
                toDoList.Name = dto.Name;
                toDoList.Description = dto.Description;
                toDoList.UserId = dto.UserId;

                _repository.Update(toDoList);
                var r = await _repository.SaveChangesAsync();
                if (r > 0)
                {
                    return new Responce<int>(toDoList.Id, true, "Saved");
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
