using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ToDoListTestApp.Hubs;
using ToDoListTestApp.Service.IService;
using ToDoListTestApp.TimerFeatures;

namespace ToDoListTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hub;
        private readonly ITimerManager _timer;
        private readonly IToDoListTaskService _toDoListTaskService;

        public NotificationController(IHubContext<NotificationHub> hubContext, ITimerManager timer, IToDoListTaskService toDoListTaskService)
        {
            _hub = hubContext;
            _timer = timer;
            _toDoListTaskService = toDoListTaskService;
        }


        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            if (!_timer.IsTimerStarted)
                _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("TransferChartData", _toDoListTaskService.UpcommingTask(id).GetAwaiter().GetResult()));
            return Ok(new { Message = "Request Completed" });
        }
    }
}
