using System.ComponentModel.DataAnnotations;

namespace ToDoListTestApp.DTO.ToDoListTasks
{
    public class ToDoListTaskDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public Guid ToDoListId { get; set; }
        public string ToDoList { get; set; }
    }
}
