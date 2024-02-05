using ToDoListTestApp.DTO.ToDoListTasks;
using ToDoListTestApp.Entity;
using ToDoListTestApp.Helper;
using ToDoListTestApp.Repository.IRepository;
using ToDoListTestApp.Service.IService;
using ToDoListTestApp.Specification.ToDoListTasks;

namespace ToDoListTestApp.Service
{
    public class ToDoListTaskService : IToDoListTaskService
    {
        private readonly IRepository<ToDoListTask> _repository;
        public ToDoListTaskService(IRepository<ToDoListTask> repository)
        {
            _repository = repository;
        }

        public async Task<Responce<int>> CreateToDoListTask(ToDoListTaskCreateDto dto)
        {
            try
            {
                ToDoListTask toDoListTask = new()
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    EndDate = dto.EndDate,
                    StartDate = dto.StartDate,
                    Status = dto.Status,
                    ToDoListId = dto.ToDoListId,
                    CreatedDate = DateTime.Now,
                };

                await _repository.AddAsync(toDoListTask);
                var r = await _repository.SaveChangesAsync();
                if (r > 0)
                {
                    return new Responce<int>(toDoListTask.Id, true, "Saved");
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

        public async Task<Responce<bool>> DeleteToDoListTaskById(int id)
        {
            try
            {
                ToDoListTask toDoListTask = await _repository.GetByIdAsync(id);

                _repository.Remove(toDoListTask);
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

        public async Task<PaginatedResponce<ToDoListTaskDto>> GetAllToDoListTasks(ToDoListTaskQueryParamsDto dto)
        {
            var spec = new GetAllToDoListTasksPaginationSpec(dto);
            var specCount = new GetAllToDoListTasksPaginationCountSpec(dto);

            var data = await _repository.GetAllAsync(spec);
            var count = await _repository.CountAsync(specCount);

            var items = data.Select(s => new ToDoListTaskDto()
            {
                Id = s.Id,
                Name = s.Name,
                Status = s.Status.ToString(),
                Description = s.Description,
                EndDate = s.EndDate,
                StartDate = s.StartDate,
                ToDoListId = s.ToDoList.Id,
                ToDoList = s.ToDoList.Name
            }).ToList();

            return new PaginatedResponce<ToDoListTaskDto>(items, count, dto.CurrentPage, dto.PageSize, true);
        }

        public async Task<Responce<ToDoListTaskDto>> GetToDoListTaskById(int id)
        {
            try
            {
                var spec = new GetToDoListTaskByIdSpec(id); ;
                ToDoListTask toDoListTask = await _repository.GetFirstOrDefaultAsync(spec);
                if (toDoListTask == null)
                {
                    List<string> errors = new()
                    {
                        "Not found"
                    };

                    return new Responce<ToDoListTaskDto>(null, false, "Failed", errors);
                }
                ToDoListTaskDto toDoListTaskDto = new()
                {
                    Id = id,
                    Name = toDoListTask.Name,
                    Status = toDoListTask.Status.ToString(),
                    Description = toDoListTask.Description,
                    EndDate = toDoListTask.EndDate,
                    StartDate = toDoListTask.StartDate,
                    ToDoListId = toDoListTask.ToDoList.Id,
                    ToDoList = toDoListTask.ToDoList.Name
                };

                if (toDoListTask != null)
                {
                    return new Responce<ToDoListTaskDto>(toDoListTaskDto, true, "Saved");
                }
                else
                {
                    List<string> errors = new()
                    {
                        "Validation error"
                    };

                    return new Responce<ToDoListTaskDto>(null, false, "Failed", errors);
                }
            }
            catch (Exception)
            {

                List<string> errors = new()
                {
                        "Sever error"
                };

                return new Responce<ToDoListTaskDto>(null, false, "Failed", errors); ;
            }
        }

        public async Task<Responce<int>> UpdateToDoListTask(ToDoListTaskUpdateDto dto)
        {
            try
            {
                ToDoListTask toDoListTask = await _repository.GetByIdAsync(dto.Id);
                toDoListTask.Name = dto.Name;
                toDoListTask.Description = dto.Description;
                toDoListTask.Status = dto.Status;
                toDoListTask.StartDate = dto.StartDate;
                toDoListTask.EndDate = dto.EndDate;
                toDoListTask.ToDoListId = dto.ToDoListId;

                _repository.Update(toDoListTask);
                var r = await _repository.SaveChangesAsync();
                if (r > 0)
                {
                    return new Responce<int>(toDoListTask.Id, true, "Saved");
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
